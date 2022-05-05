using DocumentConverter.Business.Documents;
using DocumentConverter.Business.Helpers;
using DocumentConverter.Data.Models;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DocumentConverter.Business.Services
{
    public class XmlParsingService : BaseParsingService
    {
        private const string Format = BusinessConstants.ParserTypes.XML;
        public override ParsedDocumentModel ParseDocument(RawDocumentModel rawDocument)
        {
            ValidateParsingInput(rawDocument, Format);

            var result = XDocument.Parse(rawDocument.Content);

            ValidateParsingResult(new { Title = result.Root?.Element("Title")?.Value, Text = result.Root?.Element("Text")?.Value });

#pragma warning disable CS8602 // Dereference of a possibly null reference. Not valid since it is validated above
            return new ParsedDocumentModel(result.Root.Element("Text").Value, result.Root.Element("Title").Value);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public override RawDocumentModel SerializeDocument(ParsedDocumentModel parsedDocument)
        {
            ValidateSerializationInput(parsedDocument);

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
            return new RawDocumentModel(result, Format);

        }
    }
}
