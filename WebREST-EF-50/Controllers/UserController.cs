using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebREST_EF_50.Assistants;
using WebREST_EF_50.Models;
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
            List<User> users = await _userService.GetUsers();
            if (users.Count == 0) return NotFound();
            return Ok();
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOneUser(int userId)
        {
            Console.WriteLine(userId);
            var user = await _userService.GetOneUser(userId);
            if(user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet("find/{query}")]
        public async Task<IActionResult> FindUser(string query)
        {
            Console.WriteLine(query);
            var user = await _userService.FindUser(query);
            if(user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        public async Task<IActionResult> PostOneUser([FromBody] User user)
        {
            Console.WriteLine(user);
            return Ok(await _userService.PostOneUser(user));
        }

        [HttpPut]
        [Consumes("application/json")]
        public async Task<IActionResult> UpdateUsers([FromBody] User user)
        {
            Console.WriteLine(user);
            return Ok(await _userService.UpdateOneUser(user));
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteOneUser([FromRoute] int userId)
        {
            return Ok(await _userService.DeleteOneUser(userId));
        }
    }
}