using back_wachify.Business_Logic_Layer.Interfaces;
using back_wachify.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_wachify.Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController( IUserService userService)
        {
            _userService = userService;
         

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserbyid(int id)
        {
            try
            {
                var user = await _userService.findById(id);
                return Ok(user);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
        [HttpGet("user/{username}")]
        public async Task<IActionResult> GetUserbyusername(string username)
        {
            try
            {
                var user = await _userService.findByusername(username);
                return Ok(user);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}
