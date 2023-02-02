using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models.ViewModels
{
    public class MemberViewModel
    {
        //This should never be called, but a view model has to have 
        //a parameterless constructor
        public MemberViewModel() 
        {
            MemberId = -1;
            HouseholdId= -1;
        }

        public MemberViewModel(Member member)
        {
            MemberId = member.MemberId;
            UserName = member.UserName;
            HouseholdId = member.HouseholdId;
            HouseholdName = member.Household?.HouseholdName ?? string.Empty;
            Icon = member.Icon;
            HouseholdIcon = member.Household?.Icon ?? string.Empty;
            MemberType = member.MemberType;
        }

        public int MemberId { get; set; }
        public string MemberType { get; set; } = "Member";
        public string Icon { get; set; } = string.Empty;
        public int HouseholdId { get; set; }

        public string HouseholdName { get; set; } = string.Empty;
        public string HouseholdIcon { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

    }
}
