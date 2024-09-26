using System.Text.Json.Nodes;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeManagement.Web.Services;

public class EmployeeService : IEmployeeService
{
    private readonly HttpClient _httpClient;

    public EmployeeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        return await _httpClient.GetFromJsonAsync<Employee[]>("api/employees");
    }

    public async Task<Employee> GetEmployee(int id)
    {
        return await _httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        try
        {
            var httpResponseMessage =
                await _httpClient.PutAsJsonAsync($"api/employees", employee);

            var objString = await httpResponseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Employee>(objString);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Employee> CreateEmployee(Employee employee)
    {
        try
        {
            var httpResponseMessage =
                await _httpClient.PostAsJsonAsync($"api/employees", employee);

            var objString = await httpResponseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Employee>(objString);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task DeleteEmployee(int id)
    {
        try
        {
            await _httpClient.DeleteAsync($"api/employees/{id}");
        }
        catch (Exception)
        {
            
        }
    }
}