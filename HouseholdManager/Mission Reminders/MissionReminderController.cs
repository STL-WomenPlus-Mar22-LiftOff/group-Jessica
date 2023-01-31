using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;

//using HouseholdManager.Mission_Reminders.MissionReminderModel;


namespace HouseholdManager.Mission_Reminders
{
    public class MissionReminderController : Controller
    {
        private readonly MissionReminderDbContext _context
            ;

        //public MissionReminderController() : this(new MissionReminderDb()) { }

        public MissionReminderController(MissionReminderDbContext context)
        {
            _context = context;
        }

        public SelectListItem[] Timezones
        {
            get
            {
                var systemTimeZones = TimeZoneInfo.GetSystemTimeZones();
                return systemTimeZones.Select(systemTimeZone => new SelectListItem
                {
                    Text = systemTimeZone.DisplayName,
                    Value = systemTimeZone.Id
                }).ToArray();
            }
        }

        // GET: Appointments
        public ActionResult Index()
        {
            var missionReminder = _context.FindAll();
            return View(missionReminder);
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            var missionReminder = _context.FindById(id.Value);
            if (missionReminder == null)
            {
                return NotFound();
            }

            return View(missionReminder);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.Timezones = Timezones;
            // Use an empty appointment to setup the default
            // values.
            var missionReminder = new MissionReminder
            {
                Timezone = "Pacific Standard Time",
                Time = DateTime.Now
            };

            return View(missionReminder);
        }

        [HttpPost]
        public ActionResult Create([Bind("ID,Name,PhoneNumber,Time,Timezone")]MissionReminder missionReminder)
        {
            missionReminder.CreatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Create(missionReminder);

                return RedirectToAction("Details", new { id = missionReminder.Id });
            }

            return View("Create", missionReminder);
        }

        // GET: Appointments/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            var missionReminder = _context.FindById(id.Value);
            if (missionReminder == null)
            {
                return NotFound();
            }

            ViewBag.Timezones = Timezones;
            return View(missionReminder);
        }

        // POST: /Appointments/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind("ID,Name,PhoneNumber,Time,Timezone")] MissionReminder missionReminder)
        {
            if (ModelState.IsValid)
            {
                _context.Update(missionReminder);
                return RedirectToAction("Details", new { id = missionReminder.Id });
            }
            return View(missionReminder);
        }

        // DELETE: Appointments/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}