using System.Collections.Generic;


namespace HouseholdManager.Mission_Reminders
{
    
        public interface IMissionReminderDatabase
    {
        void Create(MissionReminderModel missionReminder);
        void Update(MissionReminderModel missionReminder);
        void Delete(int id);
        MissionReminderModel FindById(int id);
        IEnumerable<MissionReminderModel> FindAll();
    }
}

