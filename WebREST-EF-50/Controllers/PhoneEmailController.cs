using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebREST_EF_50.Assistants;
using WebREST_EF_50.Services;

namespace WebREST_EF_50.Controllers
{
    [ApiController]
    [Route(RouteNames.PhoneEmailRoute)]
    public class PhoneEmailController : ControllerBase
    {
        private IPhonesEmailService _phonesEmailService;

        public PhoneEmailController(IPhonesEmailService phonesEmailService)
        {
            _phonesEmailService = phonesEmailService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhones([FromRoute] int id)
        {
            return Ok(await _phonesEmailService.GetPhones(id));
        }
    }
}