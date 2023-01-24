using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using NuGet.Protocol;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HouseholdManager.Areas.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<Member>
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

        public DbSet<Household> Households { get; set; }


        //These columns needs to be set to Unicode in order to store icon emojis
        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity("HouseholdManager.Models.Room", b =>
            {
                b.Property<string>("Icon").IsUnicode(true);
            });

            mb.Entity("HouseholdManager.Models.Member", b =>
            {
                b.Property<string>("Icon").IsUnicode(true);
            });

            mb.Entity("HouseholdManager.Models.Household", b =>
            {
                b.Property<string>("Icon").IsUnicode(true);
            });
        }

    }
}

