using NotinoTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotinoTest.Business.Modules
{
    public interface IDocumentModule
    {
        public RawDocumentModel LoadFile(string sourceFileLocation, string sourceType, string targetType);

        public void SaveFile(RawDocumentModel sourceFile, string targetFileLocation, string targetType, string targetFileType);
    }
}
