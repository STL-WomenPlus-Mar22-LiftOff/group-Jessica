using Microsoft.Owin;
using Owin;
using Syncfusion.EJ2.Maps;
using HouseholdManager.Mission_Reminders;

[assembly: OwinStartup(typeof(Startup))]
namespace HouseholdManager.Mission_Reminders
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