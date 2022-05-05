namespace DocumentConverter.Data.Models
{
    public interface IFileLocationDescriptor
    {
        public string? FileName { get; }
        public string? Url { get; }

        // public string? Email { get; set; }
    }
}