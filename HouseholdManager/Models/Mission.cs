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

        [DisplayName("Mission Name")]
        public string Name { get; set; }

        [DisplayName("Room")]
        public int? RoomId { get; set; }

        public Room? Room { get; set; }

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
