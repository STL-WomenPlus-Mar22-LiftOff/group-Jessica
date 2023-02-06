using HouseholdManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using HouseholdManager.Domain.Messages;
using HouseholdManager.Models.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace HouseholdManager.Controllers
{
    [Authorize]
    public class SendController : Controller
    
        {
           private readonly IApplicationDbRepository _repository;
        //private readonly IUserRepository _userRepository;
        private readonly INotifier _notifier;

        public SendController(
            IApplicationDbRepository applicationDbRepository,
            //IUserRepository userRepository,
            INotifier notifier)
        {
            _repository = applicationDbRepository;
            //_userRepository = userRepository;
            _notifier = notifier;
        }


        // GET: Reservation/Create/1
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var property = await _repository.FindMessagePropertyFirstOrDefaultAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            ViewData["MessageProperty"] = property;
            return View();
        }

        // POST: Reservation/Create/1
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Message,MessagePropertyId")] Send send)
        {
            if (id != send.MessagePropertyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = await _repository.GetUserAsync(HttpContext.User);
                send.Status = MessageStatus.Pending;
                send.Name = user.UserName;
                send.PhoneNumber = user.PhoneNumber;
                send.CreatedAt = DateTime.Now;

                await _repository.CreateSendAsync(send);
                var notification = Notification.BuildAdminNotification(
                    await _repository.FindSendWithRelationsAsync(send.SendId));

                await _notifier.SendNotificationAsync(notification);

                return RedirectToAction("Index", "MessageProperty");
            }

            ViewData["MessageProperty"] = await _repository.FindMessagePropertyFirstOrDefaultAsync(
                send.MessagePropertyId);
            return View(send);
        }

    }
}
