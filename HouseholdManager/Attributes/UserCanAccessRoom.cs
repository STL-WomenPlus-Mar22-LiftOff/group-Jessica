using HouseholdManager.Areas.Identity.Data;
using HouseholdManager.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Attributes
{
    public class UserCanAccessRoom : ValidationAttribute
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Member> _userManager;

        public UserCanAccessRoom(ApplicationDbContext context, UserManager<Member> userManager) 
        { 
            _context = context;
            _userManager = userManager;
        }


        /*
        protected override async ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult("Cannot validate null value");
        }
        */
        /*
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var _context = validationContext.GetService(typeof(ApplicationDbContext))
                                             as ApplicationDbContext;
            if (_context is null)
            {
                yield return new ValidationResult("Validation unable to get ApplicationDbContext.");
            }
            //Check if room exists
            Room? selectedRoom = _context!.Rooms.Find((Room x) => x.Id == RoomId);
            if (selectedRoom == null)
            {
                yield return
            }

        }
        */
    }
}
