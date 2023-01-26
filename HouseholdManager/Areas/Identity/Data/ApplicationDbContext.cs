using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using NuGet.Protocol;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HouseholdManager.Areas.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
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

        public DbSet<IdentityUser> IdentityUsers { get; set; }

        //This column needs to be set to Unicode in order to store icon emojis
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity("HouseholdManager.Models.Room", b =>
            {
                b.Property<string>("Icon").IsUnicode(true);
            });

            SeedHousehold(builder);
            SeedRoles(builder);
            SeedUsers(builder);
            SeedUserRoles(builder);
            SeedUserMember(builder);
            SeedRoom(builder);
            SeedMission(builder);
        }

        private static void SeedHousehold(ModelBuilder builder)
        {
            Household households = new Household()
            {
                HouseholdId = 1,
                HouseholdName = "DefaultHousehold",
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
            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            IdentityUser user = new IdentityUser();

            IdentityUser appAdmin = new IdentityUser()
            {
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
            builder.Entity<IdentityUser>().HasData(appAdmin);

            IdentityUser appUser = new IdentityUser()
            {
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
            builder.Entity<IdentityUser>().HasData(appUser);
        }

        private static void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { UserId = "a1addd14-6340-4840-95c2-db12554843e5", RoleId = "fab4fac1-c546-41de-aebc-a14da6895711" },
                new IdentityUserRole<string>() { UserId = "a1addd14-6340-4840-95c2-db12554843e5", RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330" },
                new IdentityUserRole<string>() { UserId = "u1ua87c6-b718-4f48-90a2-458e0a2443e6", RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330" });
        }

        private static void SeedUserMember(ModelBuilder builder)
        {
            Member member1 = new Member() { MemberId = 1, MemberType = "Admin", HouseholdId = 1, UserName = "defaultAdmin@yahoo.com", MemberIcon = "👩‍🔧" };
            builder.Entity<Member>().HasData(member1);
            Member member2 = new Member() { MemberId = 2, MemberType = "Member", HouseholdId = 1, UserName = "defaultUser@yahoo.com", MemberIcon = "👩‍💼" };
            builder.Entity<Member>().HasData(member2);
        }

        private static void SeedRoom(ModelBuilder builder)
        {
            Room room1 = new Room() { RoomId = 1, Name = "Kitchen", Icon = "🥄" };
            builder.Entity<Room>().HasData(room1);
            Room room2 = new Room() { RoomId = 2, Name = "Bathroom", Icon = "🧻" };
            builder.Entity<Room>().HasData(room2);
            Room room3 = new Room() { RoomId = 3, Name = "Master Bedroom", Icon = "🛏" };
            builder.Entity<Room>().HasData(room3);
            Room room4 = new Room() { RoomId = 4, Name = "Living Room", Icon = "🛋" };
            builder.Entity<Room>().HasData(room4);
            Room room5 = new Room() { RoomId = 5, Name = "Bedroom", Icon = "🛏" };
            builder.Entity<Room>().HasData(room5);
            Room room6 = new Room() { RoomId = 6, Name = "Guest Bedroom", Icon = "🛏" };
            builder.Entity<Room>().HasData(room6);
            Room room7 = new Room() { RoomId = 7, Name = "Master Bathroom", Icon = "🧻" };
            builder.Entity<Room>().HasData(room7);
            Room room8 = new Room() { RoomId = 8, Name = "Dining Room", Icon = "🍽" };
            builder.Entity<Room>().HasData(room8);
            Room room9 = new Room() { RoomId = 9, Name = "Yard", Icon = "🌳" };
            builder.Entity<Room>().HasData(room9);
        }

        private static void SeedMission(ModelBuilder builder)
        {
            Mission mission1 = new Mission() { MissionId = 1, MissionName = "Wash dishes", Point = 2, DueDate = DateTime.Now, RoomId = 1, MemberId = 2, };
            builder.Entity<Mission>().HasData(mission1);
            Mission mission2 = new Mission() { MissionId = 2, MissionName = "Make bed", Point = 1, DueDate = DateTime.Now, RoomId = 5, MemberId = 1, };
            builder.Entity<Mission>().HasData(mission2);
            Mission mission3 = new Mission() { MissionId = 3, MissionName = "Make bed", Point = 1, DueDate = DateTime.Now, RoomId = 3, MemberId = 2, };
            builder.Entity<Mission>().HasData(mission3);
            Mission mission4 = new Mission() { MissionId = 4, MissionName = "Mow lawn", Point = 5, DueDate = DateTime.Now, RoomId = 9, MemberId = 1, };
            builder.Entity<Mission>().HasData(mission4);
            Mission mission5 = new Mission() { MissionId = 5, MissionName = "Make dinner", Point = 4, DueDate = DateTime.Now, RoomId = 1, MemberId = 1, };
            builder.Entity<Mission>().HasData(mission5);
        }


    }
}
