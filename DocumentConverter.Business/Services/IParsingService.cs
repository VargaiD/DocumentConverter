using DocumentConverter.Business.Documents;
using DocumentConverter.Data.Models;

namespace DocumentConverter.Business.Parsing
{
    public interface IParsingService
    {
        public ParsedDocumentModel ParseDocument(RawDocumentModel rawDocument);
        public RawDocumentModel SerializeDocument(ParsedDocumentModel parsedDocument);
    }
}
