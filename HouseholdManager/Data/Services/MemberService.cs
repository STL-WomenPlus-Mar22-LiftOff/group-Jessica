using HouseholdManager.Areas.Identity.Data;
using HouseholdManager.Data.Interfaces;
using HouseholdManager.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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
        private ClaimsPrincipal user;

        public MemberService(UserManager<Member> userManager, ApplicationDbContext context, IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _context = context;
            _accessor = accessor;
            user = _accessor?.HttpContext?.User ?? throw new MemberAccessException($"MemberService unable to access current user");
        }

        public virtual async Task<Member> GetCurrentMember()
        {
            return await _userManager.GetUserAsync(user);
        }

        public virtual async Task<List<Member>> GetCurrentHouseholdMembers()
        {
            var currentMember = await GetCurrentMember();
            var members = from member in _context.Members
                          where member.HouseholdId == currentMember.HouseholdId
                          select member;
            return members.ToList();
        }

        public virtual async Task<Household> GetCurrentHousehold()
        {
            var currentMember = await GetCurrentMember();
            var household = from house in _context.Households
                            where house.Id == currentMember.HouseholdId
                            select house;
            return household.FirstOrDefault() ?? throw new KeyNotFoundException($"{currentMember.UserName}'s Household is null.");
        }

        public virtual async Task<List<Room>> GetCurrentHouseholdRooms()
        {
            var household = await GetCurrentHousehold();
            var rooms = from room in _context.Rooms
                        where room.Id == household.Id
                        select room;
            return rooms.ToList();
        }
        
        public virtual async Task<List<Mission>> GetCurrentHouseholdMissions()
        {
            var household = await GetCurrentHousehold();
            var missions = from mission in _context.Missions
                           where mission.HouseholdId == household.Id
                           select mission;
            return missions.ToList();
        }
    }
}
