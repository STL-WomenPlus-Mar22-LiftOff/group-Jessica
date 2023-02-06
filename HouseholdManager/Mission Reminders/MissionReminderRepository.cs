using HouseholdManager.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HouseholdManager.Mission_Reminders
{
    public class MissionReminderRepository: IMissionReminderDatabase 
    {
        private readonly MissionReminderDb _context = new MissionReminderDb();

       

        

        public void Create(MissionReminderModel missionReminder)
        {
            _context.MissionReminderModel.Add(missionReminder);
            _context.SaveChanges();
        }

        public void Update(MissionReminderModel missionReminder)
        {
            _context.Entry(missionReminder).State = EntityState.Modified;
            _context.Entry(missionReminder).Property(model => model.CreatedAt).IsModified = false;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var missionReminder = FindById(id);
            _context.MissionReminderModel.Remove(missionReminder);
            _context.SaveChanges();
        }

        public MissionReminderModel FindById(int id)
        {
            return _context.MissionReminderModel.Find(id);
        }

        public IEnumerable<MissionReminderModel> FindAll()
        {
            return _context.MissionReminderModel.ToList();
        }

        
    }
}