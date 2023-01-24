using Microsoft.Owin;
using Owin;
using Syncfusion.EJ2.Maps;

[assembly: OwinStartup(typeof(HouseholdManager.Mission_Reminders.Startup))]
namespace AppointmentReminders.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Hangfire.ConfigureHangfire(app);
            Hangfire.InitializeJobs();
        }
    }
}