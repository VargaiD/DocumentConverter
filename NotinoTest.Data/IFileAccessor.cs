using NotinoTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotinoTest.Data
{
    public interface IFileAccessor
    {
        public RawDocument LoadFile(FileLocationDescriptor fileLocation);

        public void SaveFile(FileLocationDescriptor fileLocation, RawDocument document);
    }
}
