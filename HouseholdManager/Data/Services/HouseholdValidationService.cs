using HouseholdManager.Areas.Identity.Data;
using HouseholdManager.Data.Interfaces;
using HouseholdManager.Models;
using Microsoft.AspNetCore.Identity;

namespace HouseholdManager.Data.Services
{
    //TODO: Add serverside validation, register service in program.cs
    public class HouseholdValidationService : IValidateHousehold
    {
        private readonly UserManager<Member> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IQueryMembers _memberService;

        public HouseholdValidationService(UserManager<Member> userManager, ApplicationDbContext context, IQueryMembers memberService)
        {
            _userManager = userManager;
            _context = context;
            _memberService = memberService;
        }
    }
}
