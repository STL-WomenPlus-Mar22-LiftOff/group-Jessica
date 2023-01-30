using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HouseholdManager.Models
{
    public class Member : IdentityUser
    {
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Member type (Administrator or Member) is required.")]
        // TODO: low priority, this should be an enum, or require a custom validation attribute
        public string MemberType { get; set; } = "Member";

        [Column(TypeName = "nvarchar(5)")]
        public string Icon { get; set; } = string.Empty;

        public ICollection<Mission> Missions { get; set; }

        public int? HouseholdId { get; set; }

        public Household? Household { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        private string _displayName = string.Empty;

        [BackingField(nameof(_displayName))]
        public string DisplayName
        {
            get
            {
                return string.IsNullOrEmpty(_displayName) ? this.UserName
                                                          : _displayName;         
            }
            set
            {
                _displayName = value;
            }
        } 

        [NotMapped]
        public string? HouseholdNameWithIcon
        {
            get
            {
                return Household == null ? "" : Household.Icon + " " + Household.Name;
            }
        }

        [NotMapped]
        public string UserNameWithIcon
        {
            get
            {
                return this.Icon + " " + this.DisplayName ?? this.UserName;
            }
        }
    }
}
