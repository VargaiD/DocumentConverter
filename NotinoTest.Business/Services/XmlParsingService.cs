using NotinoTest.Business.Documents;
using NotinoTest.Shared.Exceptions;
using NotinoTest.Business.Helpers;
using NotinoTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace NotinoTest.Business.Parsing
{
    public class XmlParsingService : IParsingService
    {
        private const string format = BusinessConstants.ParserTypes.XML;
        public ParsedDocumentModel ParseDocument(RawDocument rawDocument)
        {
            if (rawDocument?.Content == null)
            {
                throw new NotinoValidationNullException(nameof(rawDocument.Content));
            }
            if (rawDocument?.Format != format)
            {
                throw new NotinoValidationException("File not in XML format");
            }
            var result = XDocument.Parse(rawDocument.Content);
            if (result.Root?.Element("title")?.Value == null)
            {
                throw new NotinoValidationException("XML file does not contain title element");
            }
            if (result.Root?.Element("text")?.Value == null)
            {
                throw new NotinoValidationException("XML file does not contain text element");
            }
            return new ParsedDocumentModel(result.Root.Element("text").Value, result.Root.Element("title").Value);
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
            XmlSerializer serializer = new XmlSerializer(typeof(ParsedDocumentModel));
            var result = string.Empty;
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    serializer.Serialize(writer, parsedDocument);
                    result = sww.ToString();
                }
            }
            return new RawDocument(result, format);

        }
    }
}
