using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotinoTest.Data.Models
{
    public class RawDocumentModel
    {
        public string Content { get; set; }
        public string Format { get; set; }

        public RawDocumentModel(string content, string format)
        {
            Content = content;
            Format = format;
        }
        public RawDocumentModel(RawDocument document) // Should be replaced by automapper
        {
            Content = document.Content;
            Format = document.Format;
        }

        public RawDocument ToRawDocument()
        {
            return new RawDocument(Content, Format); // Should be replaced by automapper
        }
    }
}
