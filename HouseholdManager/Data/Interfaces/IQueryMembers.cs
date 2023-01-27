using HouseholdManager.Areas.Identity.Data;
using HouseholdManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HouseholdManager.Data.Interfaces
{
    public interface IQueryMembers
    {
        public abstract Task<Member> GetCurrentMember();
        public abstract Task<List<Member>> GetMembersInHousehold();
        public abstract Task<Household> GetCurrentHousehold();
    }
}
