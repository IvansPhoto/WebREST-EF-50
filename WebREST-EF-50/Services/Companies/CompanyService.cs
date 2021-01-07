﻿using System;
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

        public async Task<List<Company.Full>> GetCompaniesForUser(int skipRecords, int perPage, int userId)
        {
            // Console.WriteLine($"skipRecords: {skipRecords}, perPage:{perPage}, userId:{userId}");
            return await _dataContext.CompaniesFull
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

        public async Task<List<Company.Full>> GetAllCompanies(int skipRecords, int perPage)
        {
            return await _dataContext.CompaniesFull
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

        public async Task<Company.Full?> GetOneCompany(int id)
        {
            return await _dataContext.CompaniesFull
                .Include(company => company.Phones)
                .Include(company => company.Emails)
                .Include(company => company.Objectives)
                .Include(company => company.Employees)
                .Include(company => company.Projects)
                .Include(company => company.ResponsibleUser)
                .Include(company => company.HqCompany)
                .FirstOrDefaultAsync(company => company.Id == id);
        }

        public async Task<Company.Full?> AddCompany(Company company)
        {
            var newCompany = await _dataContext.CompaniesFull.AddAsync(new Company.Full(company));
            var rows = await _dataContext.SaveChangesAsync();
            return rows == 0 ? null : newCompany.Entity;
        }

        public async Task<Company.Full?> UpdateCompany(Company company)
        {
            var updatedCompany = _dataContext.CompaniesFull.Update(new Company.Full(company));
            var rows = await _dataContext.SaveChangesAsync();
            return rows == 0 ? null : updatedCompany.Entity;
        }

        public async Task<int> DeleteCompany(int id)
        {
            _dataContext.CompaniesFull.Remove(
                await _dataContext.CompaniesFull.FirstOrDefaultAsync(com => com.Id == id)
            );
            return await _dataContext.SaveChangesAsync();
        }
    }
}