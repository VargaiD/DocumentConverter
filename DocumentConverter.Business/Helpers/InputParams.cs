namespace DocumentConverter.Business.Helpers
{
    public class InputParams
    {
        public string SourceFileLocation { get; set; }

        public string TargetFileLocation { get; set; }

        public string SourceFileLocationType { get; set; }

        public string TargetFileLocationType { get; set; }

        public InputParams(string sourceFileLocation, string targetFileLocation, string sourceFileLocationType, string targetFileLocationType)
        {
            SourceFileLocation = sourceFileLocation;
            TargetFileLocation = targetFileLocation;
            SourceFileLocationType = sourceFileLocationType;
            TargetFileLocationType = targetFileLocationType;
        }
    }
}
