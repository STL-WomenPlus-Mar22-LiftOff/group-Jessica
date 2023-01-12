using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "Member Name is required.")]
        public string MemberName { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        [Required(ErrorMessage = "Member type (Admin or Member) is required.")]
        public string Position { get; set; } = "Member";

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MemberIcon { get; set; } = "";

        [NotMapped]
        public string? MemberNameWithIcon
        {
            get
            {
                return this.MemberIcon + " " + this.MemberName;
            }
        }
    }
}
