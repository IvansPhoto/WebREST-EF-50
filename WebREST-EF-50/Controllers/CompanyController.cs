using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebREST_EF_50.Assistants;
using WebREST_EF_50.Models;
using WebREST_EF_50.Services.Companies;

namespace WebREST_EF_50.Controllers
{
    [ApiController]
    [Route(RouteNames.CompanyRoute)]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetCompanyOfUser(int userId, int skip, int perPage)
        {
            if (skip < 0 || perPage < 1 || userId < 1) return BadRequest();
            var companies = await _companyService
                .GetCompaniesForUser(userId: userId, perPage: perPage, skipRecords: skip);
            return companies.Count == 0 ? NotFound() : Ok(companies);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies(int skip, int perPage)
        {
            if (skip < 0 || perPage < 1) return BadRequest();
            var companies = await _companyService.GetAllCompanies(skip, perPage);
            return companies.Count == 0 ? NotFound() : Ok(companies);
        }

        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetOneCompany(int companyId)
        {
            if (companyId < 1) return BadRequest();
            var company = await _companyService.GetOneCompany(companyId);
            return company == null ? NotFound() : Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(Company company)
        {
            var result = await _companyService.AddCompany(company);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany(Company company)
        {
            var result = await _companyService.UpdateCompany(company);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var result = await _companyService.DeleteCompany(id);
            return result < 1 ? NotFound() : Ok(result);
        }
    }
}