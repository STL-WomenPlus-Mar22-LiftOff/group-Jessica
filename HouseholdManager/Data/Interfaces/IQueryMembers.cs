using HouseholdManager.Areas.Identity.Data;
using HouseholdManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HouseholdManager.Data.Interfaces
{
    /// <summary>
    /// This uses the "trait" design pattern to implement shared methods related 
    /// to accessing a household and its members.
    /// </summary>
    public interface IQueryMembers
    {
        public virtual async Task<Member> GetCurrentMember(UserManager<Member> userManager, ClaimsPrincipal user)
        {
            return await userManager.GetUserAsync(user);
        }

        public virtual async Task<List<Member>> GetMembersInHousehold(UserManager<Member> userManager, ClaimsPrincipal user, ApplicationDbContext context)
        {
            var currentMember = await GetCurrentMember(userManager, user);
            var members = (from house in context.Households
                           where house.Id == currentMember.HouseholdId
                           select house.Members).FirstOrDefault()!.ToList();
            return members;
        }

        public virtual async Task<Household> GetCurrentHousehold(UserManager<Member> userManager, ClaimsPrincipal user, ApplicationDbContext context)
        {
            var currentMember = await GetCurrentMember(userManager, user);
            var household = from house in context.Households
                            where house.Id == currentMember.HouseholdId
                            select house;
            return household.FirstOrDefault() ?? throw new KeyNotFoundException($"{currentMember.UserName}'s Household is null.");
        }
    }
}
