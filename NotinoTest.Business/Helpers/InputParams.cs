using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotinoTest.Business.Helpers
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
