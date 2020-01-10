using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoutineApi.Services;

namespace RoutineApi.Controllers
{
    [ApiController]
    [Route("api/Companies")]
    public class CompaniesController:ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _companyRepository.GetCompaniesAsync();
            return new JsonResult(companies);
        }
    }
}
