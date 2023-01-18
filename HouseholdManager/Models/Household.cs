using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public string HouseholdName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string HouseholdIcon { get; set; } = "";

        [NotMapped]
        public string? HouseholdNameWithIcon
        {
            get
            {
                return this.HouseholdIcon + " " + this.HouseholdName;
            }
        }

    }
}
