using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebREST_EF_50.Data;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly DataContext _dataContext;

        public CompanyService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Company>> GetCompaniesForUser(int skipRecords, int perPage, int useId = 0)
        {
            return await _dataContext.Company
                .Skip(skipRecords)
                .Take(perPage)
                .Where(company => company.ResponsibleUser.Id == useId)
                .Include(company => company.Phones)
                .Include(company => company.Emails)
                .Include(company => company.Objectives)
                .Include(company => company.Employees)
                .Include(company => company.Projects)
                .Include(company => company.ResponsibleUser)
                .Include(company => company.HqCompany)
                .ToListAsync();
        }

        public async Task<List<Company>> GetAllCompanies(int skipRecords, int perPage)
        {
            return await _dataContext.Company
                .Skip(skipRecords)
                .Take(perPage)
                .Include(company => company.Phones)
                .Include(company => company.Emails)
                .Include(company => company.Objectives)
                .Include(company => company.Employees)
                .Include(company => company.Projects)
                .Include(company => company.ResponsibleUser)
                .Include(company => company.HqCompany)
                .ToListAsync();
        }

        public async Task<Company> GetOneCompany(int id)
        {
            return await _dataContext.Company
                .Include(company => company.Phones)
                .Include(company => company.Emails)
                .Include(company => company.Objectives)
                .Include(company => company.Employees)
                .Include(company => company.Projects)
                .Include(company => company.ResponsibleUser)
                .Include(company => company.HqCompany)
                .FirstOrDefaultAsync(company => company.Id == id);
        }

        public async Task<Company?> AddCompany(Company company)
        {
            var newCompany = await _dataContext.Company.AddAsync(company);
            var rows = await _dataContext.SaveChangesAsync();
            return rows == 0 ? null : newCompany.Entity;
        }

        public async Task<Company?> UpdateCompany(Company company)
        {
            var updatedCompany = _dataContext.Company.Update(company);
            var rows = await _dataContext.SaveChangesAsync();
            return rows == 0 ? null : updatedCompany.Entity;
        }

        public async Task<int> DeleteCompany(int id)
        {
            _dataContext.Company.Remove(
                await _dataContext.Company.FirstOrDefaultAsync(com => com.Id == id)
            );
            return await _dataContext.SaveChangesAsync();
        }
    }
}