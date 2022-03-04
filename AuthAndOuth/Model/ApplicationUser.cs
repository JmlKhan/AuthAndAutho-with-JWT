using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AuthAndOuth.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Surname { get; set; }
    }
}
