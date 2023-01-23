using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HouseholdManager.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50, ErrorMessage = "Room name is limited to 50 characters")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        
        [Column(TypeName = "nvarchar(5)")]
        public string Icon { get; set; } = "";

        [Range(1, int.MaxValue, ErrorMessage = "Invalid Household ID")]
        [ForeignKey(nameof(Household))]
        public int? HouseholdId { get; set; }

        public Household? Household { get; set; }
    }
}
