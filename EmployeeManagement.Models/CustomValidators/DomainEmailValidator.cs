using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.CustomValidators;

public class DomainEmailValidator : ValidationAttribute
{
    public string AllowedDomain { get; set; }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var email = value.ToString().Split("@");
        if (string.Equals(email[1], AllowedDomain, StringComparison.CurrentCultureIgnoreCase))
        {
            return null;
        }

        return new ValidationResult($"Domain must be {AllowedDomain}",
            new[] { validationContext.MemberName });
    }
}