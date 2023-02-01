using Hangfire;
using Hangfire.Server;
using HouseholdManager.Mission_Reminders;
using Owin;
using Syncfusion.EJ2.Maps;
using Microsoft.AspNetCore.SignalR;

using Microsoft.AspNetCore.StaticFiles;


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
            RecurringJob.AddOrUpdate<Mission_Reminders.MissionReminderSendReminder>(job => job.Execute(), Cron.Minutely);
        }
    }

    internal class MissionReminderSendReminder
    {
        internal void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
