using DocumentConverter.Data.Models;

namespace DocumentConverter.Data.Accessors
{
    public interface IFileAccessor
    {
        /// <summary>
        /// Loads file from specified location
        /// </summary>
        /// <param name="fileLocation">File location specification</param>
        /// <returns></returns>
        public RawDocument LoadFile(IFileLocationDescriptor fileLocation);

        /// <summary>
        /// Saves file to specified location
        /// </summary>
        /// <param name="fileLocation">File location specification</param>
        /// <param name="document">File to be saved</param>
        public void SaveFile(IFileLocationDescriptor fileLocation, RawDocument document);
    }
}
