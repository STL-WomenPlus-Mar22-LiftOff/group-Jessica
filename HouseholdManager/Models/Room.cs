using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HouseholdManager.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        
        [Column(TypeName = "nvarchar(20)")]
        public string Icon { get; set; } = "";

        [Range(0, 10, ErrorMessage = "Dirt level must be between 0 and 10.")]
        [DisplayName("Dirt-O-Meter")]
        public int DirtLevel { get; set; } = 0;
    }
}
