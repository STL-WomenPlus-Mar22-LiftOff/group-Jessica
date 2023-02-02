using Microsoft.AspNetCore.Identity;

namespace HouseholdManager.Models
{
    public class TwilioUser:IdentityUser
    {
        public string? Name { get; set; }
    }
}
