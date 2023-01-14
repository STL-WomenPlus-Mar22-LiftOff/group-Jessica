using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        
        [Column(TypeName = "nvarchar(5)")]
        public string Icon { get; set; } = "";

        public ICollection<Mission> Missions { get; set; }
    }
}
