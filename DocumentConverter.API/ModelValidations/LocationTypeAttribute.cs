using DocumentConverter.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DocumentConverter.API.ModelValidations
{
    public class LocationTypeAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
            "File location type is not allowed";

        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            var type = (string?)value;

            if (type == null || !Constants.FileStorageTypes.AllTypes.Contains(type))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
