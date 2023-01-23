
using System.Diagnostics.Contracts;

namespace HouseholdManager.Models.ViewModels
{
    public class MemberViewModel
    {
        public MemberViewModel(Member m) 
        {
            NameWithIcon = m?.MemberUserNameWithIcon ?? "";
            MemberType = m?.MemberType ?? "Invalid Type";
            MemberId = m?.MemberId;
            HouseholdId = m?.HouseholdId;
        }

        public int? HouseholdId { get; set; }

        public string NameWithIcon { get; private set; }

        public string HouseholdWithIcon { get; set; }

        public string MemberType { get; private set; }

        public int? MemberId { get; private set; }
    }
}
