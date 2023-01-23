using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseholdManager.Models
{
    public class Household
    {
        [Key]
        public int HouseholdId { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        [StringLength(50, ErrorMessage = "Household name is limited to 75 characters")]
        [Required(ErrorMessage = "Household name is required.")]
        public string HouseholdName { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string Icon { get; set; } = "";

        [NotMapped]
        public string? HouseholdNameWithIcon
        {
            get
            {
                return this.Icon + " " + this.HouseholdName;
            }
        }

        public ICollection<Member>? Members { get; set; }

        public ICollection<Room>? Rooms { get; set; }

        public List<Mission> Missions
        {
            get
            {
                List<Mission> memberMissions = new List<Mission>();
                if (Members is null) return memberMissions;
                foreach (var member in Members)
                {
                    if (member.Missions is null) continue;
                    foreach (var mission in member.Missions)
                    {
                        memberMissions.Add(mission);
                    }
                }
                return memberMissions;
            }
        }
    }
}
