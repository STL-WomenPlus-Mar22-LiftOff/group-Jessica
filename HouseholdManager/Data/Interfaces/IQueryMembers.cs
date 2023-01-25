using HouseholdManager.Models;

namespace HouseholdManager.Data.Interfaces
{
    public interface IQueryMembers
    {
        protected abstract Member GetCurrentMember();
        protected abstract List<Member> GetMembersInHousehold();
    }
}
