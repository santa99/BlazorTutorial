using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages;

public partial class EditEmployeeBase : ComponentBase
{
    public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();

    public Employee Employee { get; set; } = new Employee();
    public List<Department> Departments { get; set; } = new();

    [Inject] public IEmployeeService EmployeeService { get; set; }

    [Inject] public IDepartmentService DepartmentService { get; set; }

    [Parameter] public string Id { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }
    
    public string PageHeader { get; set; }

    protected async override Task OnInitializedAsync()
    {
        int.TryParse(Id, out int employeeId);

        if (employeeId != 0)
        {
            Employee = await EmployeeService.GetEmployee(employeeId);
            PageHeader = "Update Employee";
        }
        else
        {
            PageHeader = "Create Employee";
            Employee = new Employee
            {
                DepartmentId = 1,
                DateOfBrith = DateTime.Now,
                PhotoPath = "images/nophoto.jpg"
            };
        }

        Departments = (await DepartmentService.GetDepartments()).ToList();
        EditEmployeeModel = new EditEmployeeModel
        {
            // Department = Departments.FirstOrDefault(department => department.DepartmentId == Employee.DepartmentId),
            Department = Employee.Department,
            Email = Employee.Email,
            Gender = Employee.Gender,
            ConfirmEmail = Employee.Email,
            DepartmentId = Employee.DepartmentId,
            EmployeeId = Employee.EmployeeId,
            FirstName = Employee.FirstName,
            LastName = Employee.LastName,
            PhotoPath = Employee.PhotoPath,
            DateOfBrith = Employee.DateOfBrith
        };
    }

    protected async Task HandleValidSubmit()
    {
        Employee = new Employee
        {
            EmployeeId = EditEmployeeModel.EmployeeId,
            DepartmentId = EditEmployeeModel.DepartmentId,
            Email = EditEmployeeModel.Email,
            Gender = EditEmployeeModel.Gender,
            FirstName = EditEmployeeModel.FirstName,
            LastName = EditEmployeeModel.LastName,
            PhotoPath = EditEmployeeModel.PhotoPath,
            DateOfBrith = EditEmployeeModel.DateOfBrith
        };

        Employee result = null;

        if (Employee.EmployeeId != 0)
        {
            result = await EmployeeService.UpdateEmployee(Employee);
        }
        else
        {
            result = await EmployeeService.CreateEmployee(Employee);
        }

        if (result != null)
        {
            NavigationManager.NavigateTo("/");
        }
    }

    protected async Task Delete_Click()
    {
        await EmployeeService.DeleteEmployee(Employee.EmployeeId);
        NavigationManager.NavigateTo("/");
    }
}