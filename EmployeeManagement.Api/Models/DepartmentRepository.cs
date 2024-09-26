using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public AppDbContext AppDbContext { get; }

        public DepartmentRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await AppDbContext.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            return await AppDbContext.Departments.FirstOrDefaultAsync(department =>
                department.DepartmentId == departmentId);
        }
    }
}