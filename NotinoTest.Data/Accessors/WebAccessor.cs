using NotinoTest.Data.Models;
using NotinoTest.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotinoTest.Data.Accessors
{
    public class WebAccessor : IFileAccessor
    {
        public RawDocument LoadFile(FileLocationDescriptor fileLocation)
        {
            if (fileLocation?.Url == null)
            {
                throw new NotinoValidationNullException(nameof(fileLocation.Url));
            }
            HttpClient client = new HttpClient();
            string result = client.GetStringAsync(fileLocation.Url).Result;
            return new RawDocument(result, fileLocation.Url.Substring(fileLocation.Url.LastIndexOf('.')));
        }

        public void SaveFile(FileLocationDescriptor fileLocation, RawDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
