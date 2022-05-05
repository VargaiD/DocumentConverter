namespace DocumentConverter.Data.Models
{
    public class FileLocationDescriptor : IFileLocationDescriptor
    {
        private string _fileName;

        public FileLocationDescriptor(string locationDescriptor)
        {
            _fileName = locationDescriptor;
        }

        public string? FileName { get => _fileName; }
        public string? Url { get => null; }
    }
}