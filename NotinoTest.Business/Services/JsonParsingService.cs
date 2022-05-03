using NotinoTest.Business.Documents;
using NotinoTest.Shared.Exceptions;
using NotinoTest.Business.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotinoTest.Data.Models;

namespace NotinoTest.Business.Parsing
{
    public class JsonParsingService : IParsingService
    {
        private const string format = BusinessConstants.ParserTypes.JSON;
        public ParsedDocumentModel ParseDocument(RawDocument rawDocument)
        {
            if (rawDocument?.Content == null)
            {
                throw new NotinoValidationNullException(nameof(RawDocument.Content));
            }
            if (rawDocument.Format != format)
            {
                throw new NotinoValidationException("File not in JSON format");
            }
            dynamic result = JObject.Parse(rawDocument.Content);
            if (result?.title == null)
            {
                throw new NotinoValidationException("JSON file does not contain title element");
            }
            if (result?.text == null)
            {
                throw new NotinoValidationException("JSON file does not contain text element");
            }
            return new ParsedDocumentModel(result.text.Value, result.title.Value);
        }

        public RawDocument SerializeDocument(ParsedDocumentModel parsedDocument)
        {
            if (parsedDocument?.Title == null)
            {
                throw new NotinoValidationNullException(nameof(parsedDocument.Title));
            }
            if (parsedDocument?.Text == null)
            {
                throw new NotinoValidationNullException(nameof(parsedDocument.Text));
            }
            return new RawDocument(JsonConvert.SerializeObject(parsedDocument), format);
        }
    }
}
