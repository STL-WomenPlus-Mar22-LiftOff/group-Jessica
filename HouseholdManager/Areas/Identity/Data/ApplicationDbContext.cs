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
            SeedHousehold(mb);
            SeedRoles(mb);
            SeedUsers(mb);
            SeedUserRoles(mb);
            SeedRoom(mb);
            SeedMission(mb);
        }

        private static void SeedHousehold(ModelBuilder builder)
        {
            Household households = new Household()
            {
                Id = 1,
                Name = "DefaultHousehold",
            };

            builder.Entity<Household>().HasData(households);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Administrator", ConcurrencyStamp = "1", NormalizedName = "Administrator" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
                );
        }

        private static void SeedUsers(ModelBuilder builder)
        {
            PasswordHasher<Member> passwordHasher = new PasswordHasher<Member>();
            Member user = new Member();

            Member appAdmin = new Member()
            {
                Icon = "👩‍🔧",
                HouseholdId = 1,
                MemberType = "Admin",
                Id = "a1addd14-6340-4840-95c2-db12554843e5",
                UserName = "defaultAdmin@yahoo.com",
                NormalizedUserName = "DEFAULTADMIN@YAHOO.COM",
                Email = "defaultAdmin@yahoo.com",
                NormalizedEmail = "DEFAULTADMIN@YAHOO.COM",
                PasswordHash = passwordHasher.HashPassword(user, "Coder77@1"),
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumber = "111-222-3333",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true
            };
            builder.Entity<Member>().HasData(appAdmin);

            Member appUser = new Member()
            {
                Icon = "👩‍💼",
                HouseholdId = 1,
                MemberType = "Member",
                Id = "u1ua87c6-b718-4f48-90a2-458e0a2443e6",
                UserName = "defaultUser@yahoo.com",
                NormalizedUserName = "DEFAULTUSER@YAHOO.COM",
                Email = "defaultUser@yahoo.com",
                NormalizedEmail = "DEFAULTUSER@YAHOO.COM",
                PasswordHash = passwordHasher.HashPassword(user, "Coder77@1"),
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumber = "111-222-3333",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true
            };
            builder.Entity<Member>().HasData(appUser);
        }

        private static void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { UserId = "a1addd14-6340-4840-95c2-db12554843e5", RoleId = "fab4fac1-c546-41de-aebc-a14da6895711" },
                new IdentityUserRole<string>() { UserId = "a1addd14-6340-4840-95c2-db12554843e5", RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330" },
                new IdentityUserRole<string>() { UserId = "u1ua87c6-b718-4f48-90a2-458e0a2443e6", RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330" });
        }

        private static void SeedRoom(ModelBuilder builder)
        {
            Room room1 = new Room() { Id = 1, Name = "Kitchen", Icon = "🥄", HouseholdId = 1 };
            builder.Entity<Room>().HasData(room1);
            Room room2 = new Room() { Id = 2, Name = "Bathroom", Icon = "🧻", HouseholdId = 1 };
            builder.Entity<Room>().HasData(room2);
            Room room3 = new Room() { Id = 3, Name = "Master Bedroom", Icon = "🛏", HouseholdId = 1 };
            builder.Entity<Room>().HasData(room3);
            Room room4 = new Room() { Id = 4, Name = "Living Room", Icon = "🛋", HouseholdId = 1 };
            builder.Entity<Room>().HasData(room4);
            Room room5 = new Room() { Id = 5, Name = "Bedroom", Icon = "🛏", HouseholdId = 1 };
            builder.Entity<Room>().HasData(room5);
            Room room6 = new Room() { Id = 6, Name = "Guest Bedroom", Icon = "🛏", HouseholdId = 1 };
            builder.Entity<Room>().HasData(room6);
            Room room7 = new Room() { Id = 7, Name = "Master Bathroom", Icon = "🧻", HouseholdId = 1 };
            builder.Entity<Room>().HasData(room7);
            Room room8 = new Room() { Id = 8, Name = "Dining Room", Icon = "🍽", HouseholdId = 1 };
            builder.Entity<Room>().HasData(room8);
            Room room9 = new Room() { Id = 9, Name = "Yard", Icon = "🌳", HouseholdId = 1 };
            builder.Entity<Room>().HasData(room9);
        }

        private static void SeedMission(ModelBuilder builder)
        {
            Mission mission1 = new Mission() { Id = 1, Name = "Wash dishes", Point = 2, DueDate = DateTime.Now, RoomId = 1, MemberId = "u1ua87c6-b718-4f48-90a2-458e0a2443e6", HouseholdId = 1 };
            builder.Entity<Mission>().HasData(mission1);
            Mission mission2 = new Mission() { Id = 2, Name = "Make bed", Point = 1, DueDate = DateTime.Now, RoomId = 5, MemberId = "a1addd14-6340-4840-95c2-db12554843e5", HouseholdId = 1 };
            builder.Entity<Mission>().HasData(mission2);
            Mission mission3 = new Mission() { Id = 3, Name = "Make bed", Point = 1, DueDate = DateTime.Now, RoomId = 3, MemberId = "u1ua87c6-b718-4f48-90a2-458e0a2443e6", HouseholdId = 1 };
            builder.Entity<Mission>().HasData(mission3);
            Mission mission4 = new Mission() { Id = 4, Name = "Mow lawn", Point = 5, DueDate = DateTime.Now, RoomId = 9, MemberId = "a1addd14-6340-4840-95c2-db12554843e5", HouseholdId = 1 };
            builder.Entity<Mission>().HasData(mission4);
            Mission mission5 = new Mission() { Id = 5, Name = "Make dinner", Point = 4, DueDate = DateTime.Now, RoomId = 1, MemberId = "a1addd14-6340-4840-95c2-db12554843e5", HouseholdId = 1 };
            builder.Entity<Mission>().HasData(mission5);
        }


    }
}
