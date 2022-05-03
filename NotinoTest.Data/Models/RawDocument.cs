using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotinoTest.Data.Models
{
    public class RawDocument
    {
        public string Content { get; set; }
        public string Format { get; set; }

        public RawDocument(string content, string format)
        {
            Content = content;
            Format = format;
        }
    }
}
