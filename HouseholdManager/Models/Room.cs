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
        public string RoomName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string RoomIcon { get; set; } = "";

        [NotMapped]
        public string? RoomNameWithIcon
        {
            get
            {
                return this.RoomIcon + " " + this.RoomName;
            }
        }
    }
}
