using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.Companies
{
    public interface ICompanyService
    {
        public Task<List<Company>> GetCompaniesForUser(int useId, int skipRecords, int perPage);
        public Task<List<Company>> GetAllCompanies(int skipRecords, int perPage);
        public Task<Company> GetOneCompany(int id);
        public Task<Company?> AddCompany(Company company);
        public Task<Company?> UpdateCompany(Company company);
        public Task<int> DeleteCompany(int id);
    }
}