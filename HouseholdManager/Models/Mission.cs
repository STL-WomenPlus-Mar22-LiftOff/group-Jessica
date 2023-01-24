using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace HouseholdManager.Models
{
    public class Mission
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]

        [Required(ErrorMessage = "Name of mission is required.")]
        [DisplayName("Mission Name")]
        public string MissionName { get; set; }

        [DisplayName("Room")]
        public int? RoomId { get; set; }

        public Room? Room { get; set; }

        [Range(1, 5, ErrorMessage = "Amount should be greater than zero and no more than five.")]
        [DisplayName("Difficulty")]
        public int Point { get; set; }

        [BindProperty, DataType(DataType.Date)]
        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }

        public string? MemberId { get; set; }

        public Member? Member { get; set; }

        public Household Household { get; set; }
        public int HouseholdId { get; set; }

    }
}
