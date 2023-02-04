/*using HouseholdManager.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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

        public DbSet<IdentityUser> IdentiyUsers { get; set; }

    }
}*/