using HouseholdManager.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HouseholdManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    { 
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }

    public DbSet<MessageProperty> MessageProperty { get; set; }

    public DbSet<Send> Send { get; set; }

    public DbSet<TwilioUser> TwilioUser { get; set; }
     
    }
}