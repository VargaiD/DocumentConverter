using NotinoTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotinoTest.Data.Accessors
{
    public class EmailAccessor : IFileAccessor
    {
        public RawDocument LoadFile(FileLocationDescriptor fileLocation)
        {
            throw new NotImplementedException();
        }

        public void SaveFile(FileLocationDescriptor fileLocation, RawDocument document)
        {
            // FileLocationDescriptor will contain email address and the document will be sent as an attachment through SMTP server of choice
            throw new NotImplementedException();
        }
    }
}
