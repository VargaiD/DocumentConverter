using DocumentConverter.Business.Documents;
using DocumentConverter.Data.Models;

namespace DocumentConverter.Business.Parsing
{
    public interface IParsingService
    {
        /// <summary>
        /// Parses document in text to object
        /// </summary>
        /// <param name="rawDocument">Document to be parsed</param>
        /// <returns></returns>
        public ParsedDocumentModel ParseDocument(RawDocumentModel rawDocument);

        /// <summary>
        /// Serializes Document object to text
        /// </summary>
        /// <param name="parsedDocument">Document to be serialized</param>
        /// <returns></returns>
        public RawDocumentModel SerializeDocument(ParsedDocumentModel parsedDocument);
    }
}
