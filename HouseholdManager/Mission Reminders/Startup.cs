using Microsoft.Owin;
using Owin;
using Syncfusion.EJ2.Maps;

[assembly: OwinStartup(typeof(HouseholdManager.Mission_Reminders.Startup))]
namespace HouseholdManager
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