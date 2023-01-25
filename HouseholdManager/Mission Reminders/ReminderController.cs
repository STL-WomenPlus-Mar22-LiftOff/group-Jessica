using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Mvc;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;

namespace HouseholdManager.Mission_Reminders
{
    public class ReminderController : Controller
    {
        private readonly IReminderRepository _repository;

        public ReminderController() : this(new ReminderRepository()) { }

        public ReminderController(IReminderRepository repository)
        {
            _repository = repository;
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
            var reminders = _repository.FindAll();
            return View(reminders);
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var reminder = _repository.FindById(id.Value);
            if (reminder == null)
            {
                return HttpNotFound();
            }

            return View(MissionReminder);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.Timezones = Timezones;
            // Use an empty appointment to setup the default
            // values.
            var reminder = new Reminder
            {
                Timezone = "Pacific Standard Time",
                Time = DateTime.Now
            };

            return View(Reminder);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,Name,PhoneNumber,Time,Timezone")] Appointment appointment)
        {
            reminder.CreatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                _repository.Create(reminder);

                return RedirectToAction("Details", new { id = reminder.Id });
            }

            return View("Create", reminder);
        }

        // GET: Appointments/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var reminder = _repository.FindById(id.Value);
            if (reminder == null)
            {
                return HttpNotFound();
            }

            ViewBag.Timezones = Timezones;
            return View(reminder);
        }

        // POST: /Appointments/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,Name,PhoneNumber,Time,Timezone")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(reminder);
                return RedirectToAction("Details", new { id = appointment.Id });
            }
            return View(appointment);
        }

        // DELETE: Appointments/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}