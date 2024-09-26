using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Models.CustomValidators;

namespace EmployeeManagement.Models;

public class EditEmployeeModel
{
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "{$1} is required")]
    [StringLength(100, MinimumLength = 2)]
    public string FirstName { get; set; }

    [Required] public string LastName { get; set; }
    
    [Required]
    [EmailAddress]
    [DomainEmailValidator(AllowedDomain = "gmail.com")]
    public string Email { get; set; }
    
    [CompareProperty("Email", 
        ErrorMessage = "Email and Confirm Email must match")]
    public string ConfirmEmail { get; set; }
    
    public DateTime DateOfBrith { get; set; }

    public Gender Gender { get; set; }

    public int DepartmentId { get; set; }
    
    public Department? Department { get; set; }

    public string PhotoPath { get; set; }
}