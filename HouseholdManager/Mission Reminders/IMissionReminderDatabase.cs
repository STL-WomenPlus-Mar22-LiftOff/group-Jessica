namespace HouseholdManager.Mission_Reminders
{
    
        public interface IMissionReminderDatabase
    {
        void Create(MissionReminder missionReminder);
        void Update(MissionReminder missionReminder);
        void Delete(int id);
        MissionReminder FindById(int id);
        IEnumerable<MissionReminder> FindAll();
    }
}

