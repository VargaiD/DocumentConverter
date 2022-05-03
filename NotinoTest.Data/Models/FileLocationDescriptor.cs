using NotinoTest.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotinoTest.Data.Models
{
    public class FileLocationDescriptor
    {
        public string? FilePath { get; set; }
        public string? RelativeFilePath { get; set; }
        public string? Url { get; set; }

        // public string? Email { get; set; }

        public FileLocationDescriptor(string locationDescriptor, string targetType)
        {
            switch (targetType)
            {
                case Constants.FileStorageTypes.File:
                    FilePath = Path.Combine(Environment.CurrentDirectory, locationDescriptor);
                    RelativeFilePath = locationDescriptor;
                    break;
                case Constants.FileStorageTypes.Url:
                   Url = locationDescriptor;
                   break;
                //case Constants.FileStorageTypes.Email:
                //    Email = locationDescriptor;
                //    break;
            }
        }
    }
}