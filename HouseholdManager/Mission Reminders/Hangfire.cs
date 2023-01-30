using Hangfire;
using Hangfire.Server;
using Owin;
using Syncfusion.EJ2.Maps;

namespace HouseholdManager.Mission_Reminders
{
    public class Hangfire
    {
        public static void ConfigureHangfire(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("DefaultConnection");

            app.UseHangfireDashboard("/jobs");
            app.UseHangfireServer();
        }

        public static void InitializeJobs()
        {
            RecurringJob.AddOrUpdate<MissionReminderSendReminder>(job => job.Execute(), Cron.Minutely);
        }
    }
}
