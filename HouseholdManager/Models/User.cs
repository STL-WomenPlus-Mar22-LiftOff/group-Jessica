using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "User Name is required.")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        [Required(ErrorMessage = "User type (Admin or User) is required.")]
        public string Position { get; set; } = "User";

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Household? Household { get; set; }

        [ForeignKey("Household")]
        public int? HouseholdId { get; set; }

    }
}
