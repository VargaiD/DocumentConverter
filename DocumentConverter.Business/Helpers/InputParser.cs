using DocumentConverter.Shared.Exceptions;
using DocumentConverter.Shared.Helpers;

namespace DocumentConverter.Business.Helpers
{
    public static class InputParser
    {
        public static InputParams ParseInputArguments(string[] args)
        {
            if (args != null && args.Length == 4 && args[0] == Constants.FileStorageTypes.File && args[2] == Constants.FileStorageTypes.File)
            {
                return new InputParams(args[1], args[3], args[0], args[2]);
            }
            throw new DocumentConverterValidationException("Please enter input in following format: " +
                    "sourceLocationDescriptionType (-f for file, -u for url) sourceLocationDescription(path or url) destLocationDescriptionType destLocationDescription");
        }
    }
}
