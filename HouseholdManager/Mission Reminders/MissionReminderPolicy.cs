﻿namespace HouseholdManager.Mission_Reminders
{
    public class MissionReminderPolicy
    {
    
    private readonly MissionReminder _missionReminder;
    private readonly ITimeConverter _timeConverter;

    public MissionReminderPolicy(MissionReminder missionReminder, ITimeConverter timeConverter)
    {
        _missionReminder = missionReminder;
        _timeConverter = timeConverter;
    }

    public bool NeedsToBeSent(DateTime currentTime)
    {
        var reminderLocalTime = GetAppointmentLocalTime()
            .AddMinutes(-MissionReminder.ReminderTime); // Notify our appointment attendee
                                                    // X minutes before the appointment time

        string formattedCurrentTime = currentTime.ToString("MM/dd/yyyy HH:mm");
        string formattedLocalTime = reminderLocalTime.ToString("MM/dd/yyyy HH:mm");
        return formattedCurrentTime == formattedLocalTime;
    }

    private DateTime GetAppointmentLocalTime()
    {
        return _timeConverter.ToLocalTime(_missionReminder.Time, _missionReminder.Timezone);
    }
}
}