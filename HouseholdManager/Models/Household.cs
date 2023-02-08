using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseholdManager.Models
{
    public class Household
    {
        [Key]
        public int HouseholdId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Household name is required.")]
        [StringLength(50, MinimumLength = 2)]
        [DisplayName("Household Name")]
        public string HouseholdName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Icon { get; set; } = "";

        [NotMapped]
        public string? HouseholdNameWithIcon
        {
            get
            {
                return this.Icon + " " + this.HouseholdName;
            }
        }

    }
}
