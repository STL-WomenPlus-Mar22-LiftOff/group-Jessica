using HouseholdManager.;
using HouseholdManager.Mission_Reminders;
using Syncfusion.EJ2.Linq;
using Twilio.Rest;

namespace HouseholdManager.Mission_Reminders
{
    public class MissionReminderFinder
    {
        private const string MessageTemplate =
            "Hi {0}. Just a reminder that you have an appointment coming up at {1}.";

        public void Execute()
        {
            var twilioRestClient = new Domain.Twilio.RestClient();

           AvailableMissionReminder().ForEach(appointment =>
                twilioRestClient.SendSmsMessage(
                appointment.PhoneNumber,
                string.Format(MessageTemplate, missionReminder.Name, missionReminder.Time.ToString("t"))));
        }

        private static IEnumerable<MissionReminder> AvailableAppointments()
        {
            return new MissionReminderFinder(new ApplicationDbContext(), new TimeConverter())
                .FindAvailableAppointments(DateTime.Now);
        }
    }
}
