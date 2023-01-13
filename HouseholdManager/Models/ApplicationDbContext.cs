using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using NuGet.Protocol;

namespace HouseholdManager.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        //protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        //{
        //    builder.Properties<DateOnly>()
        //        .HaveConversion<DateOnlyConverter>()
        //        .HaveColumnType("date");

        //    builder.Properties<DateOnly?>()
        //        .HaveConversion<NullableDateOnlyConverter>()
        //        .HaveColumnType("date");
        //}


        public DbSet<Room> Rooms { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<HouseholdManager.Models.User> User { get; set; }


    }
}

