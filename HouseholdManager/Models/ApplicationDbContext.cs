using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;

namespace HouseholdManager.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
                
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<HouseholdManager.Models.User> User { get; set; }


    }
}
