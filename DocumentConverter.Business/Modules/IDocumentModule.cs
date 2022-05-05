using Autofac;
using DocumentConverter.Data.Models;

namespace DocumentConverter.Business.Modules
{
    public interface IDocumentModule
    {
        public RawDocumentModel LoadFile(string sourceFileLocation, string sourceType, string targetType, IContainer container);

        public void SaveFile(RawDocumentModel sourceFile, string targetFileLocation, string targetType, string targetFileType, IContainer container);
    }
}
