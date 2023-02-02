using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HouseholdManager.Models.Repositories
{
    public interface IUserRepository
    {
        Task<TwilioUser> GetUserAsync(ClaimsPrincipal user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly UserManager<TwilioUser> _userManager;

        public UserRepository(UserManager<TwilioUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<TwilioUser> GetUserAsync(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }
    }
}