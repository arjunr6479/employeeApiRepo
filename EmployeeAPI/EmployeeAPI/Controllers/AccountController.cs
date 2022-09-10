using EmployeeAPI.Model.Domain;

using EmployeeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //Step1 of DI
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public AccountController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;

        }
        [HttpPost]
        public IActionResult Authenticate([FromBody] User user)//Model Binding-Modeling hTTp request as model user
        {
            var token = jwtAuthenticationManager.Authenticate(user.username, user.password);
            if (token == null)
            {
                return Unauthorized();

            }
            return Ok("Your Token=" + token);
        }
    }
}