using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models.ViewModels
{
    public class EditHouseholdViewModel
    {
        [StringLength(50, ErrorMessage = "Household name is limited to 50 characters.")]
        [Required(ErrorMessage = "Household name is required.")]
        public string Name { get; set; }

        [StringLength(5, ErrorMessage = "Invalid icon.")]
        [Required]
        public string Icon { get; set; } = "";
    }
}
