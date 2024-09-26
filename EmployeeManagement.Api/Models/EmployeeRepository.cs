using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {

        public EmployeeRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public AppDbContext AppDbContext { get; }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await AppDbContext.Employees.AddAsync(employee);
            await AppDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = await AppDbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (result != null)
            {
                AppDbContext.Employees.Remove(result);
                await AppDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var employee = await AppDbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (employee != null) 
            {
                var department = AppDbContext.Departments.FirstOrDefault(e => e.DepartmentId == employee.DepartmentId);
                employee.Department = department;
            }
            

            // return await AppDbContext.Employees
            //     .Include(e => e.Department)
            //     .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await AppDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await AppDbContext.Employees
                .FirstOrDefaultAsync(predicate: e => e.EmployeeId == employee.EmployeeId);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBrith = employee.DateOfBrith;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await AppDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await AppDbContext.Employees.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> employees = AppDbContext.Employees;

            if (!string.IsNullOrEmpty(name))
            {
                employees = employees.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }

            if (gender != null)
            {
                employees = employees.Where(e => e.Gender == gender);
            }

            return await employees.ToListAsync();
        }
    }
}
