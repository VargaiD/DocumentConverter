using NotinoTest.Data;
using NotinoTest.Shared.Exceptions;
using NotinoTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotinoTest.Business.FileTools
{
    public class FileSystemAccessor : IFileAccessor
    {
        public RawDocument LoadFile(FileLocationDescriptor fileLocation)
        {
            if (fileLocation?.FilePath == null)
            {
                throw new NotinoValidationNullException(nameof(fileLocation.FilePath));
            }
            return new RawDocument(File.ReadAllText(fileLocation.FilePath), Path.GetExtension(fileLocation.FilePath));
        }

        public void SaveFile(FileLocationDescriptor fileLocation, RawDocument document)
        {
            if (fileLocation?.FilePath != null && document != null)
            {
                File.WriteAllText(fileLocation.FilePath, document.Content);
            }
        }
    }
}
