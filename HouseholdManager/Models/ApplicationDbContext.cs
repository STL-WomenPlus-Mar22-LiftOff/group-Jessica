using Microsoft.EntityFrameworkCore;

namespace HouseholdManager.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
                
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Task> Tasks { get; set; }


    }
}
