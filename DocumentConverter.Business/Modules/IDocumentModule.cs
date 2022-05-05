using Autofac;
using DocumentConverter.Data.Models;

namespace DocumentConverter.Business.Modules
{
    public interface IDocumentModule
    {
        /// <summary>
        /// Loads file from storage in specified type
        /// </summary>
        /// <param name="sourceFileLocation">File location description (file name, url...)</param>
        /// <param name="sourceType">Storage type (filesystem, url)</param>
        /// <param name="targetFileType">Type of file to be returned</param>
        /// <param name="container">Depency Container</param>
        /// <returns></returns>
        public RawDocumentModel LoadFile(string sourceFileLocation, string sourceType, string targetFileType, IContainer container);

        /// <summary>
        /// Saves file to storage in specified type
        /// </summary>
        /// <param name="sourceFile">File to be saved</param>
        /// <param name="targetFileLocation">File location description (file name, url...)</param>
        /// <param name="targetType">Storage type (filesystem, url)</param>
        /// <param name="targetFileType">Type of file to be saved</param>
        /// <param name="container">Depency Container</param>
        public void SaveFile(RawDocumentModel sourceFile, string targetFileLocation, string targetType, string targetFileType, IContainer container);
    }
}
