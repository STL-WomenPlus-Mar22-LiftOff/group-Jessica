using Microsoft.AspNetCore.Identity;

namespace HouseholdManager.Areas.Identity.Data
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }


        public string? LastName { get; set; }

        public int? Age { get; set; }
    }
}