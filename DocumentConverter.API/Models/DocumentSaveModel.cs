using DocumentConverter.API.ModelValidations;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DocumentConverter.API.Models
{
    public class DocumentSaveModel
    {

        [Required]
        [NotNull]
        public string? Location { get; set; }

        [Required]
        [NotNull]
        [LocationType]
        public string? LocationType { get; set; }

        [Required]
        [NotNull]
        [FileType]
        public string? SourceFormat { get; set; }

        [Required]
        [NotNull]
        [FileType]
        public string? TargetFormat { get; set; }
    }
}
