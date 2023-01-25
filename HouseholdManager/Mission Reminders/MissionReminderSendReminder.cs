using Twilio.Rest;
using HouseholdManager.Mission_Reminders.Repository;
using HouseholdManager.Mission_Reminders.MissionReminderFinder;


namespace HouseholdManager.Mission_Reminders
{
    public class MissionReminderSendReminder
    {
    
        private const string MessageTemplate =
            "Hi {0}. Just a reminder that you have an appointment coming up at {1}.";

    public void Execute()
    {
        var twilioRestClient = new Domain.Twilio.RestClient();

        AvailableAppointments().ForEach(appointment =>
            twilioRestClient.SendSmsMessage(
            appointment.PhoneNumber,
            string.Format(MessageTemplate, appointment.Name, appointment.Time.ToString("t"))));
    }

    private static IEnumerable<MissionReminder> AvailableAppointments()
    {
        return new MissionReminderFinder(new ReminderRepository(), new TimeConverter())
            .FindAvailableAppointments(DateTime.Now);
    }
}
}