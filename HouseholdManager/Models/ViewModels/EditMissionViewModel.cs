using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models.ViewModels
{
    public class EditMissionViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name of mission is required.")]
        [DisplayName("Mission Name")]
        public string Name { get; set; }

        [DisplayName("Room")]
        public int? RoomId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Point value must be greater than zero and no more than five.")]
        [DisplayName("Difficulty")]
        public int Point { get; set; }

        [BindProperty, DataType(DataType.Date)]
        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }

        public string? MemberId { get; set; }
    }
}
