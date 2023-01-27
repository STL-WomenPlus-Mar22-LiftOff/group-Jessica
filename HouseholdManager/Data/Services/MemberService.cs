using HouseholdManager.Areas.Identity.Data;
using HouseholdManager.Data.Interfaces;
using HouseholdManager.Models;
using Microsoft.AspNetCore.Identity;

namespace HouseholdManager.Data.Services
{
    /// <summary>
    /// Provides methods to access the current, logged in Member and related objects.
    /// Use this by dependency injecting an IQueryMembers into a constructor.
    /// </summary>
    public class MemberService : IQueryMembers
    {
        private readonly UserManager<Member> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _accessor;

        public MemberService(UserManager<Member> userManager, ApplicationDbContext context, IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _context = context;
            _accessor = accessor;
        }

        public virtual async Task<Member> GetCurrentMember()
        {
            var user = _accessor.HttpContext.User;
            return await _userManager.GetUserAsync(user);
        }

        public virtual async Task<List<Member>> GetMembersInHousehold()
        {
            var user = _accessor.HttpContext.User;
            var currentMember = await GetCurrentMember();
            var members = (from house in _context.Households
                           where house.Id == currentMember.HouseholdId
                           select house.Members).FirstOrDefault()!.ToList();
            return members;
        }

        public virtual async Task<Household> GetCurrentHousehold()
        {
            var user = _accessor.HttpContext.User;
            var currentMember = await GetCurrentMember();
            var household = from house in _context.Households
                            where house.Id == currentMember.HouseholdId
                            select house;
            return household.FirstOrDefault() ?? throw new KeyNotFoundException($"{currentMember.UserName}'s Household is null.");
        }
    }
}
