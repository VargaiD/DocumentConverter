using DocumentConverter.API.ModelValidations;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DocumentConverter.API.Models
{
    public class DocumentLoadModel
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
        public string? Format { get; set; }
    }
}
