using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebREST_EF_50.Data;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _dataContext;

        public EmployeeService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<List<Employee>> GetEmployeesById(int skipRecords, int perPage,
            int userId = 0, int companyId = 0)
        {
            return await _dataContext.Employees
                .Skip(skipRecords)
                .Take(perPage)
                .Where(employee => companyId != 0 && employee.Company != null && employee.Company.Id == companyId || 
                                   userId != 0 && employee.ResponsibleUser.Id == userId)
                .ToListAsync();
        }

        public async Task<List<Employee>> GetAllEmployees(int skipRecords, int perPage)
        {
            return await _dataContext.Employees
                .Skip(skipRecords)
                .Take(perPage)
                .ToListAsync();
        }

        public async Task<Employee> GetOneEmployee(int id)
        {
            return await _dataContext.Employees.FirstOrDefaultAsync(employee => employee.Id == id);
        }

        public async Task<Employee?> AddEmployee(Employee employee)
        {
            var newEmployee = await _dataContext.Employees.AddAsync(employee);
            var rows = await _dataContext.SaveChangesAsync();
            return rows == 0 ? null : newEmployee.Entity;
        }

        public async Task<Employee?> UpdateEmployee(Employee employee)
        {
            var updatedEmployee = _dataContext.Employees.Update(employee);
            var rows = await _dataContext.SaveChangesAsync();
            return rows == 0 ? null : updatedEmployee.Entity;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            _dataContext.Remove(
                await _dataContext.Employees.FirstOrDefaultAsync(employee => employee.Id == id)
            );
            return await _dataContext.SaveChangesAsync();
        }
    }
}