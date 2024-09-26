using Common.Components;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages;

public class DisplayEmployeeBase : ComponentBase
{
    [Parameter]
    public Employee Employee { get; set; }
    
    [Parameter]
    public bool ShowFooter { get; set; }
    
    [Parameter]
    public EventCallback<int> OnEmployeeDeleted { get; set; }
    
    [Inject]
    public IEmployeeService EmployeeService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }
    
    protected bool IsSelected { get; set; }
    
    [Parameter]
    public EventCallback<bool> OnEmployeeSelection { get; set; }
    
    protected ConfirmBase DeleteConfirmation { get; set; }
    
    protected async Task OnCheckBoxChecked(ChangeEventArgs e)
    {
        IsSelected = (bool)e.Value;
        await OnEmployeeSelection.InvokeAsync(IsSelected);
    }

    protected async Task Delete_Click(EventArgs e)
    {
        // await ConfirmDelete_Click(true);
        DeleteConfirmation.Show();
    }
    
    protected async Task ConfirmDelete_Click(bool deleteConfirmed)
    {
        if(deleteConfirmed)
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
        }
    }
}