using DocumentConverter.Business.Documents;
using DocumentConverter.Business.Parsing;
using DocumentConverter.Data.Models;
using DocumentConverter.Shared.Exceptions;

namespace DocumentConverter.Business.Services
{
    public abstract class BaseParsingService : IParsingService
    {
        protected static void ValidateParsingInput(RawDocumentModel rawDocument, string documentFormat)
        {
            if (rawDocument == null || rawDocument.Content == null)
            {
                throw new DocumentConverterValidationNullException(nameof(RawDocumentModel.Content));
            }
            if (rawDocument.Format != documentFormat)
            {
                throw new DocumentConverterValidationException($"File not in {documentFormat} format");
            }
        }

        protected static void ValidateParsingResult(dynamic result)
        {
            if (result.Title == null)
            {
                throw new DocumentConverterValidationException("File does not contain title element");
            }
            if (result.Text == null)
            {
                throw new DocumentConverterValidationException("File does not contain text element");
            }
        }

        protected static void ValidateSerializationInput(ParsedDocumentModel parsedDocument)
        {
            if (parsedDocument?.Title == null)
            {
                throw new DocumentConverterValidationNullException(nameof(parsedDocument.Title));
            }
            if (parsedDocument?.Text == null)
            {
                throw new DocumentConverterValidationNullException(nameof(parsedDocument.Text));
            }
        }

        public abstract ParsedDocumentModel ParseDocument(RawDocumentModel rawDocument);
        public abstract RawDocumentModel SerializeDocument(ParsedDocumentModel parsedDocument);
    }
}
