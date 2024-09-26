using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services;

public class DepartmentService : IDepartmentService
{
    private readonly HttpClient _httpClient;

    public DepartmentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Department>> GetDepartments()
    {
        return await _httpClient.GetFromJsonAsync<Department[]>("api/departments");
    }

    public async Task<Department> GetDepartment(int id)
    {
        return await _httpClient.GetFromJsonAsync<Department>($"api/departments/{id}");
    }
}