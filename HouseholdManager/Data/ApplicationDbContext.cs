using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using NuGet.Protocol;

namespace HouseholdManager.Data
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
        public DbSet<Member> Members { get; set; }

        //This column needs to be set to Unicode in order to store icon emojis
        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            mb.Entity("HouseholdManager.Models.Room", b =>
            {
                b.Property<string>("Icon").IsUnicode(true);
            });
        }

    }
}

