using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotinoTest.Business.Documents
{
    public class ParsedDocumentModel
    {
        public string Text { get; set; }
        public string Title { get; set; }

        public ParsedDocumentModel(string text, string title)
        {
            Text = text;
            Title = title;
        }

        internal ParsedDocumentModel() { }
    }
}
