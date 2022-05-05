using Autofac;
using DocumentConverter.Business.Parsing;
using DocumentConverter.Data.Accessors;
using DocumentConverter.Data.Models;

namespace DocumentConverter.Business.Modules
{
    public class SimpleDocumentModule : IDocumentModule
    {
        public RawDocumentModel LoadFile(string sourceFileLocation, string sourceType, string targetFileType, IContainer container)
        {
            var fileAccessor = container.ResolveNamed<IFileAccessor>(sourceType);
            var sourceFileDescirptor = container.ResolveNamed<IFileLocationDescriptor>(sourceType, new NamedParameter("locationDescriptor", sourceFileLocation));
            var rawDoc = new RawDocumentModel(fileAccessor.LoadFile(sourceFileDescirptor));
            return Convert(rawDoc, targetFileType, container);
        }

        public void SaveFile(RawDocumentModel sourceFile, string targetFileLocation, string targetType, string targetFileType, IContainer container)
        {
            var targetFileDescirptor = container.ResolveNamed<IFileLocationDescriptor>(targetType, new NamedParameter("locationDescriptor", targetFileLocation));
            var fileAccessor = container.ResolveNamed<IFileAccessor>(targetType);
            fileAccessor.SaveFile(targetFileDescirptor, Convert(sourceFile, targetFileType, container).ToRawDocument());
        }

        private RawDocumentModel Convert(RawDocumentModel document, string targetType, IContainer container)
        {
            var sourceParser = container.ResolveNamed<IParsingService>(document.Format);
            var targetParser = container.ResolveNamed<IParsingService>(targetType);
            var parsed = sourceParser.ParseDocument(document);
            return targetParser.SerializeDocument(parsed);
        }
    }
}
