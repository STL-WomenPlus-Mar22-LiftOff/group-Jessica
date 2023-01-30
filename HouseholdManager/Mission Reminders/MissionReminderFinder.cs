using NuGet.Protocol.Core.Types;

namespace HouseholdManager.Mission_Reminders
{
    public class MissionReminderFinder
    {
    
    private readonly IMissionReminderDatabase _context
            ;
    private readonly ITimeConverter _timeConverter;
        private MissionReminder missionReminder;

        public MissionReminderFinder(IMissionReminderDatabase context, ITimeConverter timeConverter)
    {
        _context = context;
        _timeConverter = timeConverter;
    }

    public IList<MissionReminder> FindAvailableMissionReminder(DateTime currentTime)
    {
        var appts = _context.FindAll();
        var availablMissionReminder = _context.FindAll()
            .Where(MissionReminder =>
                new MissionReminderPolicy(
                    missionReminder, _timeConverter)
                .NeedsToBeSent(currentTime));


        return availableMissionReminder.ToList();
    }
}
}