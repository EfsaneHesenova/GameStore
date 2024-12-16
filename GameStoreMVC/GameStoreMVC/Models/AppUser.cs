using Microsoft.AspNetCore.Identity;

namespace GameStoreMVC.Models
{
    public class AppUser: IdentityUser
    {
        public string FirtName { get; set; }
        public string LastName { get; set; }
    }
}
