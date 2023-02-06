/*using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HouseholdManager.Models.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityUser> GetUserAsync(ClaimsPrincipal user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityUser> GetUserAsync(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }
    }
}*/