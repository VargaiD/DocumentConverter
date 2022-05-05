using DocumentConverter.Data.Models;

namespace DocumentConverter.Data.Accessors
{
    public interface IFileAccessor
    {
        public RawDocument LoadFile(IFileLocationDescriptor fileLocation);

        public void SaveFile(IFileLocationDescriptor fileLocation, RawDocument document);
    }
}
