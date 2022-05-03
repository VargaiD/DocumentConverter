using Autofac;
using NotinoTest.Business.Parsing;
using NotinoTest.Data;
using NotinoTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotinoTest.Business.Modules
{
    public class SimpleDocumentModule : IDocumentModule
    {
        public RawDocumentModel LoadFile(string sourceFileLocation, string sourceType, string targetFileType)
        {
            var fileAccessor = DependencyHelper.Container.ResolveNamed<IFileAccessor>(sourceType);
            var sourceFileDescirptor = new FileLocationDescriptor(sourceFileLocation, sourceType);
            var rawDoc = fileAccessor.LoadFile(sourceFileDescirptor);
            return new RawDocumentModel(Convert(rawDoc, targetFileType));
        }

        public void SaveFile(RawDocumentModel sourceFile, string targetFileLocation, string targetType, string targetFileType)
        {
            var targetFileDescirptor = new FileLocationDescriptor(targetFileLocation, targetType);
            var fileAccessor = DependencyHelper.Container.ResolveNamed<IFileAccessor>(targetType);
            fileAccessor.SaveFile(targetFileDescirptor, Convert(sourceFile.ToRawDocument(), targetFileType));
        }

        private RawDocument Convert(RawDocument document, string targetType)
        {
            var sourceParser = DependencyHelper.Container.ResolveNamed<IParsingService>(document.Format);
            var targetParser = DependencyHelper.Container.ResolveNamed<IParsingService>(targetType);
            var parsed = sourceParser.ParseDocument(document);
            return targetParser.SerializeDocument(parsed);
        }
    }
}
