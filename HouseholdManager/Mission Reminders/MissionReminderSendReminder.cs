using Twilio.Rest;
using HouseholdManager.ApplicationDb;
using HouseholdManager.Mission_Reminders;
using HouseholdManager.Areas.Identity.Data;
using Syncfusion.EJ2.Linq;

namespace HouseholdManager.Mission_Reminders
{
    public class MissionReminderSendReminder
    {
    
        private const string MessageTemplate =
            "Hi {0}. Just a reminder that you have an mission due at {1}.";

    public void Execute()
    {
        var twilioRestClient = new RestClient();

        AvailableMissionReminder().ForEach(missionReminder =>
            twilioRestClient.SendSmsMessage(
            missionReminder.PhoneNumber,
            string.Format(MessageTemplate, missionReminder.Name, missionReminder.Time.ToString("t"))));
    }

    private static IEnumerable<MissionReminderModel> AvailableMissionReminder()
    {
        return new MissionReminderFinder(new ApplicationDbContext(), new TimeConverter())
            .FindAvailableAppointments(DateTime.Now);
    }
}
}