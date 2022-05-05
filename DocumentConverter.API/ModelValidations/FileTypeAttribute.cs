using DocumentConverter.Shared.Helpers;
using System.ComponentModel.DataAnnotations;

namespace DocumentConverter.API.ModelValidations
{
    public class FileTypeAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
            "File type is not allowed";

        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            var type = (string?)value;

            if (type == null || !Constants.ParserTypes.AllTypes.Contains(type))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
