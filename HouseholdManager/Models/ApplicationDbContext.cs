using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using HouseholdManager.Data;

namespace HouseholdManager.Models
{
    public class ApplicationDbContext : HouseholdManagerContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
                
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Contributor> Contributors { get; set; }


    }
}
