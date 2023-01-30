using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models.ViewModels
{
    public class EditMemberProfileViewModel
    {
        public string UserName;

        [StringLength(50, ErrorMessage = "Display name is limited to 50 characters.")]
        public string DisplayName;

        [StringLength(5, ErrorMessage = "Invalid icon.")]
        public string Icon;
    }
}
