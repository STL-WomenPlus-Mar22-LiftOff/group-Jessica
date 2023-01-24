using Microsoft.Owin;
using Owin;
using Syncfusion.EJ2.Maps;

[assembly: OwinStartup(typeof(AppointmentReminders.Web.Startup))]
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