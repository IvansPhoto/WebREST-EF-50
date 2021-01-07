using System;
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

        public async Task<List<ICompanyFull>> GetCompaniesForUser(int skipRecords, int perPage, int userId)
        {
            // Console.WriteLine($"skipRecords: {skipRecords}, perPage:{perPage}, userId:{userId}");
            return await _dataContext.Companies
                .OrderBy(company => company.Id)
                .Skip(skipRecords)
                .Take(perPage)
                .Where(company => company.ResponsibleUser.Id == userId)
                .Include(company => company.Phones)
                .Include(company => company.Emails)
                .Include(company => company.Objectives)
                .Include(company => company.Employees)
                .Include(company => company.Projects)
                .Include(company => company.ResponsibleUser)
                .Include(company => company.HqCompany)
                .ToListAsync();
        }

        public async Task<List<ICompanyFull>> GetAllCompanies(int skipRecords, int perPage)
        {
            return await _dataContext.Companies
                .OrderBy(company => company.Id)
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

        public async Task<ICompanyFull?> GetOneCompany(int id)
        {
            return await _dataContext.Companies
                .Include(company => company.Phones)
                .Include(company => company.Emails)
                .Include(company => company.Objectives)
                .Include(company => company.Employees)
                .Include(company => company.Projects)
                .Include(company => company.ResponsibleUser)
                .Include(company => company.HqCompany)
                .FirstOrDefaultAsync(company => company.Id == id);
        }

        public async Task<ICompanyFull?> AddCompany(ICompanyBase companyBase)
        {
            var newCompany = await _dataContext.Companies.AddAsync(new CompanyFull(companyBase));
            var rows = await _dataContext.SaveChangesAsync();
            return rows == 0 ? null : newCompany.Entity;
        }

        public async Task<ICompanyFull?> UpdateCompany(ICompanyBase companyBase)
        {
            var updatedCompany = _dataContext.Companies.Update(new CompanyFull(companyBase));
            var rows = await _dataContext.SaveChangesAsync();
            return rows == 0 ? null : updatedCompany.Entity;
        }

        public async Task<int> DeleteCompany(int id)
        {
            _dataContext.Companies.Remove(
                await _dataContext.Companies.FirstOrDefaultAsync(com => com.Id == id)
            );
            return await _dataContext.SaveChangesAsync();
        }
    }
}