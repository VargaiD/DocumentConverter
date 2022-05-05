using DocumentConverter.Data.Models;

namespace DocumentConverter.Data.Accessors
{
    public class EmailAccessor : IFileAccessor
    {
        public RawDocument LoadFile(IFileLocationDescriptor fileLocation)
        {
            throw new NotImplementedException();
        }

        public void SaveFile(IFileLocationDescriptor fileLocation, RawDocument document)
        {
            // FileLocationDescriptor will contain email address and the document will be sent as an attachment through SMTP server of choice
            throw new NotImplementedException();
        }
    }
}
