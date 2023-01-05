using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        //RoomId-Foreign Key
        [Range(1, int.MaxValue, ErrorMessage = "Please select a room")]
        public int RoomId { get; set; }

        public Room? Room { get; set; }

        [Range(1, 5, ErrorMessage = "Amount should be greater than zero and no more than five.")]
        public int Point { get; set; }

    }
}
