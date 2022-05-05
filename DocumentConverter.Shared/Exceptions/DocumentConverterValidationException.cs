namespace DocumentConverter.Shared.Exceptions
{
    public class DocumentConverterValidationException : ArgumentException
    {
        public DocumentConverterValidationException(string? message) : base(message)
        {
        }
    }
}
