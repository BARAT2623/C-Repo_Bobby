using System;
using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Validators
{
    public class DateCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date = value as DateTime?;

            // Date must be today or in the future
            if (date != null && date < DateTime.Now.Date)
            {
                return new ValidationResult("Admission date cannot be earlier than today");
            }

            return ValidationResult.Success;
        }
    }
}
