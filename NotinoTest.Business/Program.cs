using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Autofac;
using NotinoTest.Business;
using NotinoTest.Business.Documents;
using NotinoTest.Shared.Exceptions;
using NotinoTest.Business.FileTools;
using NotinoTest.Business.Helpers;
using NotinoTest.Business.Parsing;
using Newtonsoft.Json;
using NotinoTest.Data.Models;
using NotinoTest.Data;

namespace Moravia.Homework
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            var success = true;
            try
            {
                var inputParams = InputParser.ParseInputArguments(args);
                Container = DependencyHelper.InitialiazeContainer();

                var sourceFile = LoadFile(inputParams.SourceFileLocation, inputParams.SourceFileLocationType);

                var parsedSourceFile = ParseSourceFile(sourceFile);

                var convertedFile = ConvertFile(inputParams.TargetFileLocation, parsedSourceFile);

                SaveFile(convertedFile, inputParams.TargetFileLocation, inputParams.TargetFileLocationType);
                
            }
            catch (Exception ex)
            {
                success = false;
                if (ex is NotinoValidationException || ex is NotinoValidationNullException)
                {
                    Console.WriteLine(ex.Message); // all errors should be translated and stored as keys ideally
                }
                else
                {
                    Console.WriteLine("Unexpected error has occured"); // exception should be logged in some kind of logging system
                }
            }
            if (success)
            {
                Console.WriteLine("File was successfully saved!");
            }
        }

        private static void SaveFile(RawDocument convertedFile, string targetFileName, string targetType)
        {
            var fileAccessor = Container.ResolveNamed<IFileAccessor>(targetType);
            var targetFileLocation = new FileLocationDescriptor(targetFileName, targetType);
            fileAccessor.SaveFile(targetFileLocation, convertedFile);
        }

        private static RawDocument ConvertFile(string targetFileName, ParsedDocumentModel parsedSourceFile)
        {
            var parser = Container.ResolveNamed<IParsingService>(Path.GetExtension(targetFileName));
            return parser.SerializeDocument(parsedSourceFile);
        }

        private static ParsedDocumentModel ParseSourceFile(RawDocument sourceFile)
        {
            var parser = Container.ResolveNamed<IParsingService>(sourceFile.Format);
            return parser.ParseDocument(sourceFile);
        }

        private static RawDocument LoadFile(string sourceFileName, string sourceType)
        {
            var fileAccessor = Container.ResolveNamed<IFileAccessor>(sourceType);
            var sourceFileLocation = new FileLocationDescriptor(sourceFileName, sourceType);
            return fileAccessor.LoadFile(sourceFileLocation);
        }
    }
}