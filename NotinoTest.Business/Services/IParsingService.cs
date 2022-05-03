using NotinoTest.Business.Documents;
using NotinoTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotinoTest.Business.Parsing
{
    public interface IParsingService
    {
        public ParsedDocumentModel ParseDocument(RawDocument rawDocument);
        public RawDocument SerializeDocument(ParsedDocumentModel parsedDocument);
    }
}
