using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models
{
    public class User
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? Age { get; set; }
    }
}
