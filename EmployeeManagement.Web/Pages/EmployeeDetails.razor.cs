using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement.Web.Pages;

public class EmployeeDetailsBase : ComponentBase
{
    [Inject] public IEmployeeService EmployeeService { get; set; }

    //Toto je parameter pre stranku a jeho meno sa musi zhodovat s tym ktory je v direktive stranky
    [Parameter] public string Id { get; set; }

    public Employee Employee { get; set; } = new Employee();

    protected override async Task OnInitializedAsync()
    {
        Id ??= "1";
        Employee = await EmployeeService.GetEmployee(int.Parse(Id));
    }

    protected string Coordinates { get; set; }
    protected string ButtonText { get; set; } = "Hide Footer";
    protected string CssClass { get; set; } = null;
    
    public void Mouse_Move(MouseEventArgs mouseEventArgs)
    {
        Coordinates = $"X = {mouseEventArgs.ClientX} Y = {mouseEventArgs.ClientY}";
    }
    
    protected void Button_Click(EventArgs eventArgs)
    {
        if (ButtonText == "Hide Footer")
        {
            ButtonText = "Show Footer";
            CssClass = "HideFooter";
        }
        else
        {
            CssClass = null;
            ButtonText = "Hide Footer";
        }
    }
}