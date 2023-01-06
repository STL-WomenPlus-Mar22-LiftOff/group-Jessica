using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;

namespace HouseholdManager.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> User { get; set; }


    }
}
