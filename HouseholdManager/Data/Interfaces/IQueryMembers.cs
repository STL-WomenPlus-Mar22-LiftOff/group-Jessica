using HouseholdManager.Models;

namespace HouseholdManager.Data.Interfaces
{
    /// <summary>
    /// Interface for dependency injection of <seealso cref="HouseholdManager.Data.Services.MemberService"/>
    /// </summary>
    public interface IQueryMembers
    {
        /// <returns>The current, logged-in Member</returns>
        public abstract Task<Member> GetCurrentMember();

        /// <returns>A list of all Members who share a Household with the current, 
        /// logged in Member (including the current Member)</returns>
        public abstract Task<List<Member>> GetCurrentHouseholdMembers();

        /// <returns><para>The current, logged in Member's Household.</para>
        /// Throws a KeyNotFoundException if the current, logged in Member 
        /// has no Household set</returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public abstract Task<Household> GetCurrentHousehold();

        /// <returns>A list of all Missions in the current, logged in Member's Household</returns>
        public abstract Task<List<Mission>> GetCurrentHouseholdMissions();

        /// <returns>A list of all Rooms in the current, logged in Member's Household</returns>
        public abstract Task<List<Room>> GetCurrentHouseholdRooms();
    }
}
