using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Models.CustomValidators;

namespace EmployeeManagement.Models;

public class Employee
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
    public DateTime DateOfBrith { get; set; }

    /// <summary>
    /// Employee gender.
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Department id associated.
    /// </summary>
    public int DepartmentId { get; set; }
    
    public Department? Department { get; set; }

    public string PhotoPath { get; set; }
}