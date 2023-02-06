using HouseholdManager.Mission_Reminders;
using NuGet.Protocol.Core.Types;

namespace HouseholdManager.Mission_Reminders
{
    public class MissionReminderFinder
    {
    
    private readonly IMissionReminderDatabase _context
            ;
    private readonly ITimeConverter _timeConverter;
        private MissionReminderModel missionReminder;

        public MissionReminderFinder(IMissionReminderDatabase context, ITimeConverter timeConverter)
    {
        _context = context;
        _timeConverter = timeConverter;
    }

        public MissionReminderFinder(MissionReminderRepository missionReminderDbContext, TimeConverter timeConverter)
        {
        }

        public IList<MissionReminderModel> FindAvailableMissionReminder(DateTime currentTime)
    {
        var appts = _context.FindAll();
        var availablMissionReminder = _context.FindAll()
            .Where(MissionReminder =>
                new MissionReminderPolicy(
                    missionReminder, _timeConverter)
                .NeedsToBeSent(currentTime));


        return availableMissionReminder.ToList();
    }

        internal IEnumerable<MissionReminderModel> FindAvailableAppointments(DateTime now)
        {
            throw new NotImplementedException();
        }
    }

    internal class availableMissionReminder
    {
        internal static IList<MissionReminderModel> ToList()
        {
            throw new NotImplementedException();
        }
    }
}