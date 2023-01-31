using HouseholdManager.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseholdManager.Mission_Reminders
{
    public class MissionReminderDbContext: ApplicationDbContext 
    {
        private readonly MissionReminderDb _context = new MissionReminderDb();

        public MissionReminderDbContext(DbContextOptions options) : base(options)
        {
        }

        public void Create(MissionReminder missionReminder)
        {
            _context.MissionReminder.Add(missionReminder);
            _context.SaveChanges();
        }

        public void Update(MissionReminder missionReminder)
        {
            _context.Entry(missionReminder).State = EntityState.Modified;
            _context.Entry(missionReminder).Property(model => model.CreatedAt).IsModified = false;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var missionReminder = FindById(id);
            _context.MissionReminder.Remove(missionReminder);
            _context.SaveChanges();
        }

        public MissionReminder FindById(int id)
        {
            return _context.MissionReminder.Find(id);
        }

        public IEnumerable<MissionReminder> FindAll()
        {
            return _context.MissionReminder.ToList();
        }

        
    }
}