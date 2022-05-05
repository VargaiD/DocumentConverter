using DocumentConverter.Data.Models;
using DocumentConverter.Shared.Exceptions;

namespace DocumentConverter.Data.Accessors
{
    public class WebAccessor : IFileAccessor
    {
        public RawDocument LoadFile(IFileLocationDescriptor fileLocation)
        {
            if (fileLocation.Url == null)
            {
                throw new DocumentConverterValidationNullException(nameof(fileLocation.Url));
            }
            HttpClient client = new HttpClient();
            string result = client.GetStringAsync(fileLocation.Url).Result;
            return new RawDocument(result, fileLocation.Url.Substring(fileLocation.Url.LastIndexOf('.')));
        }

        public void SaveFile(IFileLocationDescriptor fileLocation, RawDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
