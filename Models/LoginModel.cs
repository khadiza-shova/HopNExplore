using Microsoft.AspNetCore.Identity;

namespace HopNExplore.Models
{
    public class LoginModel
    {
        public string Email { get; set; } // optional extra field
        public string Password { get; set; } // optional extra field
        // public bool RememberMe { get; set; } // optional extra field
    }
}
