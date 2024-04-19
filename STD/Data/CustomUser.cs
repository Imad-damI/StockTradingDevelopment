using Microsoft.AspNetCore.Identity;

namespace STD.Data
{
    public class CustomUser : IdentityUser
    {
        public string Wallet { get; set; } // Add any additional properties here
    }
}
