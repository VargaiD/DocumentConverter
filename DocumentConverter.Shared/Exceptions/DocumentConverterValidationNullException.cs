namespace DocumentConverter.Shared.Exceptions
{
    public class DocumentConverterValidationNullException : ArgumentNullException
    {
        public DocumentConverterValidationNullException(string? paramName) : base(paramName)
        {
        }
    }
}
