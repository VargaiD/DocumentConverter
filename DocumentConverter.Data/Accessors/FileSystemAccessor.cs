using DocumentConverter.Shared.Exceptions;
using DocumentConverter.Data.Models;

namespace DocumentConverter.Data.Accessors
{
    public class FileSystemAccessor : IFileAccessor
    {
        private string StorageFolder { get => Path.Combine(Environment.CurrentDirectory, "DocumentStorage"); }

        public RawDocument LoadFile(IFileLocationDescriptor fileLocation)
        {
            if (fileLocation.FileName == null)
            {
                throw new DocumentConverterValidationNullException(nameof(fileLocation.FileName));
            }
            var path = Path.Combine(StorageFolder, fileLocation.FileName);
            if (!File.Exists(path))
            {
                throw new DocumentConverterValidationException("File does not exist");
            }
            return new RawDocument(File.ReadAllText(path), Path.GetExtension(path));
        }

        public void SaveFile(IFileLocationDescriptor fileLocation, RawDocument document)
        {
            if (fileLocation?.FileName != null && document != null)
            {
                var path = Path.Combine(StorageFolder, fileLocation.FileName);
                File.WriteAllText(path, document.Content);
            }
        }
    }
}
