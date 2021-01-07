using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.Companies
{
    public interface ICompanyService
    {
        public Task<List<Company.Full>> GetCompaniesForUser(int skipRecords, int perPage, int userId);
        public Task<List<Company.Full>> GetAllCompanies(int skipRecords, int perPage);
        public Task<Company.Full?> GetOneCompany(int id);
        public Task<Company.Full?> AddCompany(Company companyBase);
        public Task<Company.Full?> UpdateCompany(Company companyBase);
        public Task<int> DeleteCompany(int id);
    }
}