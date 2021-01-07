using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.Employees
{
    public interface IEmployeeService
    {
        public Task<List<Employee.Full>> GetEmployeesById(int skipRecords, int perPage,
            int userId = 0, int companyId = 0);
        public Task<List<Employee.Full>> GetAllEmployees(int skipRecords, int perPage);
        public Task<Employee.Full> GetOneEmployee(int id);
        public Task<Employee.Full?> AddEmployee(Employee employeeBase);
        public Task<Employee.Full?> UpdateEmployee(Employee employeeBase);
        public Task<int> DeleteEmployee(int id);
    }
}