using HouseholdManager.Mission_Reminders;
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

        public MissionReminderFinder(MissionReminderDbContext missionReminderDbContext, TimeConverter timeConverter)
        {
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

    internal class availableMissionReminder
    {
        internal static IList<MissionReminder> ToList()
        {
            throw new NotImplementedException();
        }
    }
}