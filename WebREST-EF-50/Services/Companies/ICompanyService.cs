using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.Companies
{
    public interface ICompanyService
    {
        public Task<List<ICompanyFull>> GetCompaniesForUser(int skipRecords, int perPage, int userId);
        public Task<List<ICompanyFull>> GetAllCompanies(int skipRecords, int perPage);
        public Task<ICompanyFull?> GetOneCompany(int id);
        public Task<ICompanyFull?> AddCompany(ICompanyBase companyBase);
        public Task<ICompanyFull?> UpdateCompany(ICompanyBase companyBase);
        public Task<int> DeleteCompany(int id);
    }
}