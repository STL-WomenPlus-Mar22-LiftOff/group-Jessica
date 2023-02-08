using System.ComponentModel.DataAnnotations;
using HouseholdManager.Areas.Identity.Data;
using HouseholdManager.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseholdManager.Data.Validation
{
    /// <summary>
    /// Custom validation attribute to prevent duplicate member profiles
    /// </summary>
    public class NotAlreadyInHousehold : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //important: validationContext member does not have a valid member ID yet
            var member = (Member)validationContext.ObjectInstance;
            int newHouseholdId = (int)value!;
            var dbContext = validationContext.GetService(typeof(ApplicationDbContext)) 
                                                         as ApplicationDbContext;

            if (dbContext is null) return new ValidationResult("Unable to access database for validation");
            if (newHouseholdId <= 0) return new ValidationResult("Invalid Household ID");

            //this probably ought to be refactored later to use user id instead of name
            Member? match = (from m in dbContext.Members.Include(u => u.User)
                             where m.UserName == member.UserName
                             select m).FirstOrDefault();
            //No member found = identity user has not been assigned a profile yet, which is ok
            if (match is null) return ValidationResult.Success;
            //Member found and existing householdId matches new one, invalidate
            else if (match.HouseholdId == newHouseholdId)
            {
                return new ValidationResult("User is already a member of that household");
            }
            else
            {
                return ValidationResult.Success;
            }
            
        }
    }
}
