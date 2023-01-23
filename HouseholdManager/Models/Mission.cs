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
        public int MissionId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50, ErrorMessage = "Mission name is limited to 50 characters")]
        [Required(ErrorMessage = "Name of mission is required.")]
        [DisplayName("Mission Name")]
        public string MissionName { get; set; }

        //RoomId-Foreign Key
        [Range(1, int.MaxValue, ErrorMessage = "Please select a room")]
        [ForeignKey(nameof(Room))]
        public int? RoomId { get; set; }

        public Room? Room { get; set; }

        [Range(1, 5, ErrorMessage = "Amount should be greater than zero and no more than five.")]
        [DisplayName("Difficulty")]
        public int Point { get; set; }

        [BindProperty, DataType(DataType.Date)]
        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }

        //MemberId-Foreign Key
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Member ID")]
        [ForeignKey(nameof(Member))]
        public int? MemberId { get; set; }

        public Member? Member { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Household ID")]
        [ForeignKey(nameof(Household))]
        public int? HouseholdId { get; set; }

        public Household? Household { get; set; }

    }
}
