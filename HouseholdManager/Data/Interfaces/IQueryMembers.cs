using HouseholdManager.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HouseholdManager.Data.Interfaces
{
    /// <summary>
    /// This uses the "trait" design pattern to implement shared methods related 
    /// to accessing a household's members.
    /// </summary>
    public interface IQueryMembers
    {
        protected virtual async Task<Member> GetCurrentMember(UserManager<Member> userManager, ClaimsPrincipal user)
        {
            return await userManager.GetUserAsync(user);
        }

        protected virtual async Task<List<Member>> GetMembersInHousehold(UserManager<Member> userManager, ClaimsPrincipal user)
        {
            var currentMember = await GetCurrentMember(userManager, user);
            var members = (from houseMember in currentMember.Household?.Members
                           select houseMember).ToList();
            return members;
        }
    }
}
