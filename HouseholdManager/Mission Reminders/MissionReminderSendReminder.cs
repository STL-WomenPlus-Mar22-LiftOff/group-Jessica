using Twilio.Rest;
using HouseholdManager.ApplicationDb;
using HouseholdManager.Mission_Reminders.MissionReminderFinder;
using HouseholdManager.Areas.Identity.Data;

namespace HouseholdManager.Mission_Reminders
{
    public class MissionReminderSendReminder
    {
    
        private const string MessageTemplate =
            "Hi {0}. Just a reminder that you have an appointment coming up at {1}.";

    public void Execute()
    {
        var twilioRestClient = new Domain.Twilio.RestClient();

        AvailableMissionReminder().ForEach(appointment =>
            twilioRestClient.SendSmsMessage(
            appointment.PhoneNumber,
            string.Format(MessageTemplate, appointment.Name, appointment.Time.ToString("t"))));
    }

    private static IEnumerable<MissionReminderModel> AvailableMissionReminder()
    {
        return new MissionReminderFinder(new ApplicationDbContext(), new TimeConverter())
            .FindAvailableAppointments(DateTime.Now);
    }
}
}