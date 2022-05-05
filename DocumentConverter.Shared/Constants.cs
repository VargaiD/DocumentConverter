using System.Reflection;

namespace DocumentConverter.Shared.Helpers
{
    public static class Constants
    {
        public static class FileStorageTypes {
            public const string File = "-f";
            public const string Url = "-u";
            // public const string Email = "-e";

            public static string[] AllTypes = new string[] { File, Url }; // Could be replaced by som generic method in both
        }
        public static class ParserTypes
        {
            public const string XML = ".xml";
            public const string JSON = ".json";

            public static string[] AllTypes = new string[] {XML, JSON };
        }
    }
}
