using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Infrastructure.Identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
