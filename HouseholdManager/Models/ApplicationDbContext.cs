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

        //This column needs to be set to Unicode in order to store icon emojis
        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            mb.Entity("HouseholdManager.Models.Room", b => {
                b.Property<string>("Icon").IsUnicode(true);
            });
        }

    }
}
