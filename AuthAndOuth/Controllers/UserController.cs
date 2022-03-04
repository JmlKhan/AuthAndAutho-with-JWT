using AuthAndOuth.Model;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthAndOuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult Admins()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.Surname}, you are {currentUser.Role}");
        }

        [HttpGet("Sellers")]
        [Authorize(Roles = "Seller, Admin")]
        public IActionResult Seller()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.Surname}, you are {currentUser.Role}");
        }

        [HttpGet("public")]
        public IActionResult Public()
        {
            return Ok("Hi, you are on public");
        }

        private ApplicationUser GetCurrentUser()
        {
            var Identity = HttpContext.User.Identity as ClaimsIdentity;

            if(Identity != null)
            {
                var UserClaims = Identity.Claims;

                return new ApplicationUser
                {
                    Username = UserClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = UserClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    Surname = UserClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Role = UserClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,

                };
            }

            return null;
        } 
    }
}
