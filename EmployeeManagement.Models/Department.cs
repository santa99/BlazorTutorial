using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models;

public class Department
{
    /// <summary>
    /// Unique department id.
    /// </summary>
    public int DepartmentId { get; set; }
    
    /// <summary>
    /// Department name.
    /// </summary>
    // [ValidateComplexType]
    public string DepartmentName { get; set; }
}