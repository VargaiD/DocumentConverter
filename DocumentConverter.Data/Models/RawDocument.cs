namespace DocumentConverter.Data.Models
{
    public class RawDocument
    {
        public string Content { get; }
        public string Format { get; }

        public RawDocument(string content, string format)
        {
            Content = content;
            Format = format;
        }
    }
}
