using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebREST_EF_50.Assistants;
using WebREST_EF_50.Models;
using WebREST_EF_50.Services.Users;

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
            var users = await _userService.GetUsers();
            if (users.Count == 0) return NotFound();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOneUser(int userId)
        {
            if (userId < 1) return BadRequest();
            var user = await _userService.GetOUserById(userId);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet("find/{query}")]
        public async Task<IActionResult> FindUser(string query)
        {
            if (query.Length == 0) return BadRequest();
            var user = await _userService.FindOneUserById(query);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> PostOneUser([FromBody] IUserBase user)
        {
            return Ok(await _userService.PostOneUser(user));
        }

        [HttpPut]
        [Consumes("application/json")]
        public async Task<IActionResult> UpdateOneUser([FromBody] IUserBase user)
        {
            return Ok(await _userService.UpdateOneUser(user));
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> DeleteOneUser([FromRoute] int userId)
        {
            if (userId < 1) return BadRequest();
            return Ok(await _userService.DeleteOneUser(userId));
        }
    }
}