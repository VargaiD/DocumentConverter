//using Autofac;
//using DocumentConverter.Business;
//using DocumentConverter.Business.Documents;
//using DocumentConverter.Shared.Exceptions;
//using DocumentConverter.Business.Helpers;
//using DocumentConverter.Business.Parsing;
//using DocumentConverter.Data.Models;
//using DocumentConverter.Data;

//namespace Moravia.Homework
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            try
//            {
//                var inputParams = InputParser.ParseInputArguments(args);

//                var sourceFile = LoadFile(inputParams.SourceFileLocation, inputParams.SourceFileLocationType);

//                var parsedSourceFile = ParseSourceFile(new RawDocumentModel(sourceFile));

//                var convertedFile = ConvertFile(inputParams.TargetFileLocation, parsedSourceFile);

//                SaveFile(convertedFile.ToRawDocument(), inputParams.TargetFileLocation, inputParams.TargetFileLocationType);
//                Console.WriteLine("File was successfully saved!");

//            }
//            catch (Exception ex)
//            {
//                if (ex is DocumentConverterValidationException or DocumentConverterValidationNullException)
//                {
//                    Console.WriteLine(ex.Message); // all errors should be translated and stored as keys ideally
//                }
//                else
//                {
//                    Console.WriteLine("Unexpected error has occured"); // exception should be logged in some kind of logging system
//                }
//            }
//        }

//        private static void SaveFile(RawDocument convertedFile, string targetFileName, string targetType)
//        {
//            var fileAccessor = DependencyHelper.Container.ResolveNamed<IFileAccessor>(targetType);
//            var targetFileLocation = new FileLocationDescriptor(targetFileName, targetType);
//            fileAccessor.SaveFile(targetFileLocation, convertedFile);
//        }

//        private static RawDocumentModel ConvertFile(string targetFileName, ParsedDocumentModel parsedSourceFile)
//        {
//            var parser = DependencyHelper.Container.ResolveNamed<IParsingService>(Path.GetExtension(targetFileName));
//            return parser.SerializeDocument(parsedSourceFile);
//        }

//        private static ParsedDocumentModel ParseSourceFile(RawDocumentModel sourceFile)
//        {
//            var parser = DependencyHelper.Container.ResolveNamed<IParsingService>(sourceFile.Format);
//            return parser.ParseDocument(sourceFile);
//        }

//        private static RawDocument LoadFile(string sourceFileName, string sourceType)
//        {
//            var fileAccessor = DependencyHelper.Container.ResolveNamed<IFileAccessor>(sourceType);
//            var sourceFileLocation = new FileLocationDescriptor(sourceFileName, sourceType);
//            return fileAccessor.LoadFile(sourceFileLocation);
//        }
//    }
//}