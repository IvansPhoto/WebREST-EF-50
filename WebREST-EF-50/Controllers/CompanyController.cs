using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebREST_EF_50.Assistants;

namespace WebREST_EF_50.Controllers
{
	[ApiController]
	[Route(RouteNames.ObjectiveRoute)]
	public class CompanyController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> GetObjectives()
		{
			return Ok();
		}
		[HttpGet()]
		public async Task<IActionResult> GetOneObjective()
		{
			return Ok();
		}
		[HttpPost]
		public async Task<IActionResult> PostObjectives()
		{
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> UpdateObjectives()
		{
			return Ok();
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteObjectives()
		{
			return Ok();
		}
	}
}