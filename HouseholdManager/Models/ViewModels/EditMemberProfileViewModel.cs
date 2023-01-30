using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models.ViewModels
{
    public class EditMemberProfileViewModel
    {
        public string? UserName { get; set; }

        [StringLength(50, ErrorMessage = "Display name is limited to 50 characters.")]
        [DisplayName("Display Name")]
        public string DisplayName { get; set; }

        //[StringLength(5, ErrorMessage = "Invalid icon.")]
        public string Icon { get; set; }
    }
}
