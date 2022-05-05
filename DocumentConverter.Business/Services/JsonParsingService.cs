using DocumentConverter.Business.Documents;
using DocumentConverter.Shared.Exceptions;
using DocumentConverter.Business.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DocumentConverter.Data.Models;

namespace DocumentConverter.Business.Services
{
    public class JsonParsingService : BaseParsingService
    {
        private const string Format = BusinessConstants.ParserTypes.JSON;
        public override ParsedDocumentModel ParseDocument(RawDocumentModel rawDocument)
        {
            ValidateParsingInput(rawDocument, Format);

            dynamic result = JObject.Parse(rawDocument.Content);

            ValidateParsingResult(new { Title = result?.title?.Value, Text = result?.text?.Value });

            if (result != null)
            {
                return new ParsedDocumentModel(result.text.Value, result.title.Value);
            }
            throw new DocumentConverterValidationNullException("Document parsing has failed");
        }

        public override RawDocumentModel SerializeDocument(ParsedDocumentModel parsedDocument)
        {
            ValidateSerializationInput(parsedDocument);

            return new RawDocumentModel(JsonConvert.SerializeObject(parsedDocument), Format);
        }
    }
}
