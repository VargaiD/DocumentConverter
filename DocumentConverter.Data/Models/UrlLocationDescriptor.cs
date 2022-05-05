namespace DocumentConverter.Data.Models
{
    public class UrlLocationDescriptor : IFileLocationDescriptor
    {
        private string _url;

        public UrlLocationDescriptor(string locationDescriptor)
        {
            _url = locationDescriptor;
        }

        public string? FileName { get => null; }
        public string? Url { get => _url; }
    }
}