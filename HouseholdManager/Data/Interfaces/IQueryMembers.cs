using HouseholdManager.Models;

namespace HouseholdManager.Data.Interfaces
{
    /// <summary>
    /// Interface for dependency injection of <seealso cref="HouseholdManager.Data.Services.MemberService"/>
    /// </summary>
    public interface IQueryMembers
    {
        public abstract Task<Member> GetCurrentMember();
        public abstract Task<List<Member>> GetCurrentHouseholdMembers();
        public abstract Task<Household> GetCurrentHousehold();
        public abstract Task<List<Mission>> GetCurrentHouseholdMissions();
        public abstract Task<List<Room>> GetCurrentHouseholdRooms();
    }
}
