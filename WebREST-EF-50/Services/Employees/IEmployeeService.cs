using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.Employees
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetEmployeesById(int skipRecords, int perPage,
            int userId = 0, int companyId = 0);
        public Task<List<Employee>> GetAllEmployees(int skipRecords, int perPage);
        public Task<Employee> GetOneEmployee(int id);
        public Task<Employee?> AddEmployee(Employee company);
        public Task<Employee?> UpdateEmployee(Employee company);
        public Task<int> DeleteEmployee(int id);
    }
}