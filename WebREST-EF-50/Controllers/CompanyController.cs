using Microsoft.AspNetCore.Mvc;

namespace WebREST_EF_50.Controllers
{
	public class CompanyController : Controller
	{
		// GET
		public IActionResult Index()
		{
			return Ok();
		}
	}
}