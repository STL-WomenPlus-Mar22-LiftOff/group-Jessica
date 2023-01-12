using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models
{
    public class Mission
    {
        [Key]
        public int MissionId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Name of mission is required.")]
        public string MissionName { get; set; }

        //RoomId-Foreign Key
        [Range(1, int.MaxValue, ErrorMessage = "Please select a room")]
        public int RoomId { get; set; }

        public Room? Room { get; set; }

        [Range(1, 5, ErrorMessage = "Amount should be greater than zero and no more than five.")]
        public int MissionPoints { get; set; }

        public DateTime DueDate { get; set; } = DateTime.Now;

        [Column(TypeName = "nvarchar(50)")]
        public string MissionIcon { get; set; } = "";

        [Range(1, int.MaxValue, ErrorMessage = "Please select a room")]
        public int MemberId { get; set; }

        public Member? Member { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? MissionInstructions { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MissionStatus { get; set; } = "ToDo";

        [NotMapped]
        public string? MissionNameWithIcon
        {
            get
            {
                return this.MissionIcon + " " + this.MissionName;
            }
        }

        [NotMapped]
        public string? RoomNameWithIcon
        {
            get
            {
                return Room == null ? "" : Room.RoomIcon + " " + Room.RoomName;
            }
        }

        [NotMapped]
        public string? MemberNameWithIcon
        {
            get
            {
                return Member == null ? "" : Member.MemberIcon + " " + Member.MemberName;
            }
        }

    }
}
