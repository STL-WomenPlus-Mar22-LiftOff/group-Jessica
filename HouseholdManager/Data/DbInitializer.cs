using HouseholdManager.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseholdManager.Data
{
    internal sealed class DbInitializer
    {
        internal static void Seed(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));

            context.Database.Migrate();
            var rooms = new Room[]
            {
                new Room{Name = "Grapefruit's Rumpus Room", Icon = "cat"},
                new Room{Name = "Kitchen", Icon = "fork"},
                new Room{Name = "Living Room", Icon = "couch"},
                new Room{Name = "Bedroom", Icon = "bed"},
                new Room{Name = "Guest Room", Icon = "bed"},
                new Room{Name = "Master Bedroom", Icon = "bed"},
                new Room{Name = "Master Bathroom", Icon = "bath"},
                new Room{Name = "Bathroom", Icon = "bath"},
                new Room{Name = "Ensuite", Icon = "bath"},
                new Room{Name = "Sun Room", Icon = "sun"},
                new Room{Name = "Dining Room", Icon = "fork"},
                new Room{Name = "Basement", Icon = "water"}, //oof
                new Room{Name = "Front Yard", Icon = "rake"},
                new Room{Name = "Back Yard", Icon = "rake"},
                new Room{Name = "Breakfast Nook", Icon = "egg"},
                new Room{Name = "Library", Icon = "book"},
                new Room{Name = "Garage", Icon = "car"},
                new Room{Name = "Patio", Icon = "todo"},
                new Room{Name = "Balcony", Icon = "todo"}
            };

            var tasks = new Models.Task[]
            {
                new Models.Task { TaskName = "Clean the kitchen", Point = 4, RoomId = 2 },
                new Models.Task { TaskName = "Fix the wobbly chair", Point = 2, RoomId = 15 }
            };

            foreach (var room in rooms)
            {
                context.Rooms.Add(room);
            }
            context.SaveChanges(); //needed here for foreign keys in tasks

            foreach (var task in tasks)
            {
                context.Tasks.Add(task);
            }
            context.SaveChanges();


        }
    }
}
