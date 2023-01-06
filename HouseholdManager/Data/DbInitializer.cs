using HouseholdManager.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseholdManager.Data
{
    internal sealed class DbInitializer
    {
        internal static void Seed(DbContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));

            context.Database.Migrate();
            var rooms = new Room[]
            {
                new Room{Name = "Kitchen", Icon = "todo"},
                new Room{Name = "Front Yard", Icon = "todo"},
                new Room{Name = "Back Yard", Icon = "todo"},
                new Room{Name = "Living Room", Icon = "todo"},
                new Room{Name = "Bedroom", Icon = "todo"},
                new Room{Name = "Guest Room", Icon = "todo"},
                new Room{Name = "Master Bedroom", Icon = "todo"},
                new Room{Name = "Master Bathroom", Icon = "todo"},
                new Room{Name = "Bathroom", Icon = "todo"},
                new Room{Name = "Ensuite", Icon = "todo"},
                new Room{Name = "Sun Room", Icon = "todo"},
                new Room{Name = "Dining Room", Icon = "todo"},
                new Room{Name = "Basement", Icon = "todo"},
                new Room{Name = "Library", Icon = "todo"},
                new Room{Name = "Breakfast Nook", Icon = "todo"},
                new Room{Name = "Garage", Icon = "todo"},
                new Room{Name = "Patio", Icon = "todo"},
                new Room{Name = "Balcony", Icon = "todo"}
            };

            var tasks = new Models.Task[]
            {
                new Models.Task { TaskName = "", Point = 4 }
            };


            //loops
            context.SaveChanges();


        }
    }
}
