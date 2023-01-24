using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseholdManager.Models
{
    public class Household
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50, ErrorMessage = "Household name is limited to 50 characters.")]
        [Required(ErrorMessage = "Household name is required.")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        [StringLength(5, ErrorMessage = "Invalid icon.")]
        public string Icon { get; set; } = "";

        public ICollection<Member> Members { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Mission> Missions { get; set; }

        [NotMapped]
        public string? NameWithIcon
        {
            get
            {
                return this.Icon + " " + this.Name;
            }
        }

    }
}
