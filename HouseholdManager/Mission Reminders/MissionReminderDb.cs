using Microsoft.EntityFrameworkCore;

namespace HouseholdManager.Mission_Reminders
{
    public class MissionReminderDb : DbContext
    {
        public MissionReminderDb()
            : base("DefaultConnection")
        {
        }


        public DbSet<MissionReminder> MissionReminder { get; set; }
    }
}
