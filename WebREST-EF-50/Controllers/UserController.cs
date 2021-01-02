using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebREST_EF_50.Assistants;
using WebREST_EF_50.Services;

namespace WebREST_EF_50.Controllers
{
    [ApiController]
    [Route(RouteNames.UserRoute)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var user = await _userService.GetUsers();
            return Ok(user);
        }

        [HttpGet()]
        public async Task<IActionResult> GetOneUser(int? id, string? query)
        {
            var user = await _userService.GetOneUser(id: id, query: query);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> PostOneUser()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsers()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOneUser()
        {
            return Ok();
        }
    }
}