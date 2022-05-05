namespace DocumentConverter.Data.Models
{
    public interface IFileLocationDescriptor
    {
        /// <summary>
        /// Name of file, used in file system
        /// </summary>
        public string? FileName { get; }

        /// <summary>
        /// File Url where it will be loaded from
        /// </summary>
        public string? Url { get; }

        // public string? Email { get; set; }
    }
}