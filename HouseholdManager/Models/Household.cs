using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Syncfusion.EJ2.Spreadsheet;
using System.Reflection;

namespace HouseholdManager.Models
{
    public class Household
    {
        [Key]
        public int HouseholdId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "A name is required for this household group.")]
        [DisplayName("Household Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A household must have at least one member!")]
        public ICollection<User> Members { get; set; }
        //public ICollection<Member> Members { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public ICollection<Mission> Missions { get; set; }

}
