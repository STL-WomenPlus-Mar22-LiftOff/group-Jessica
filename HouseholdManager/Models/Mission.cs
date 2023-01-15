using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HouseholdManager.Models
{
    public class Mission
    {
        [Key]
        public int MissionId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Name")]
        [Required(ErrorMessage = "Name of mission is required.")]
        public string MissionName { get; set; }

        //RoomId-Foreign Key
        [Range(1, int.MaxValue, ErrorMessage = "Please select a room")]
        [DisplayName("Room")]
        public int RoomId { get; set; }

        public Room? Room { get; set; }

        [Range(1, 5, ErrorMessage = "Amount should be greater than zero and no more than five.")]
        [DisplayName("Difficulty")]
        public int Point { get; set; }

        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }

    }
}
