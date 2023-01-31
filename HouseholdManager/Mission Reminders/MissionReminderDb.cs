using HouseholdManager.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseholdManager.Mission_Reminders
{
    public class MissionReminderDb : ApplicationDbContext
    {
        public MissionReminderDb()
            : base("DefaultConnection")
        {
        }


        public DbSet<MissionReminder> MissionReminder { get; set; }
    }
}
