using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models.ViewModels
{
    public class EditRoomViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Room names are limited to 50 characters.")]
        public string Name { get; set; }

        [StringLength(5, ErrorMessage = "Invalid icon.")]
        public string Icon { get; set; }
    }
}
