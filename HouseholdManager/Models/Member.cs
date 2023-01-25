using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Member type (Administrator or Member) is required.")]
        public string MemberType { get; set; } = "Member";

        [Column(TypeName = "nvarchar(50)")]
        public string MemberIcon { get; set; } = "";

        //HouseholdId-Foreign Key
        [Range(1, int.MaxValue, ErrorMessage = "Please select household")]
        public int HouseholdId { get; set; }

        public Household? Household { get; set; }

        public string UserName { get; set; }

        public IdentityUser? User { get; set; }

        [NotMapped]
        public string? HouseholdNameWithIcon
        {
            get
            {
                return Household == null ? "" : Household.HouseholdIcon + " " + Household.HouseholdName;
            }
        }

        [NotMapped]
        public string? MemberUserNameWithIcon
        {
            get
            {
                return this.MemberIcon + " " + this.UserName;
            }
        }
    }
}
