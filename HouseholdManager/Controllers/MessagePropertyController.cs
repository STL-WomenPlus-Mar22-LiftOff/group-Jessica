using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using HouseholdManager.Models.Repositories;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HouseholdManager.Models;


namespace HouseholdManager.Controllers
{
    [Authorize]
    public class MessagePropertyController : Controller
    {
        
            private readonly IApplicationDbRepository _repository;

            private readonly IUserRepository _userRepository;

            public MessagePropertyController(
                IUserRepository userRepository,
                IApplicationDbRepository repository)
            {
                _userRepository = userRepository;
                _repository = repository;
            }

            // GET: VacationProperty
            public async Task<IActionResult> Index()
            {
                return View(await _repository.ListAllMessagePropertyAsync());
            }

            // GET: VacationProperty/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: MessageProperty/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Description,")] MessageProperty messageProperty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userRepository.GetUserAsync(HttpContext.User);
                    messageProperty.UserId = user.Id;
                    messageProperty.CreatedAt = DateTime.Now;

                    await _repository.CreateMessagePropertyAsync(messageProperty);
                    return RedirectToAction(nameof(Index));
                }
                return View(messageProperty);
            }

            // GET: VacationProperty/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var messageProperty = await _repository.FindMessagePropertyFirstOrDefaultAsync(id);
                if (messageProperty == null)
                {
                    return NotFound();
                }
                ViewData["UserId"] = messageProperty.UserId;
                return View(messageProperty);
            }

            // POST: messageProperty/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] MessageProperty messagePropertyUpdate)
            {
                if (id != messagePropertyUpdate.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    var messageProperty = await _repository.FindMessagePropertyFirstOrDefaultAsync(id);

                    if (messageProperty == null)
                    {
                        return NotFound();
                    }
                    await _repository.UpdateMessagePropertyAsync(messageProperty);

                    return RedirectToAction(nameof(Index));
                }
                ViewData["UserId"] = messagePropertyUpdate.UserId;
                return View(messagePropertyUpdate);
            }

            // GET: VacationProperty/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var messageProperty = await _repository.FindMessagePropertyFirstOrDefaultAsync(id);
                if (messageProperty == null)
                {
                    return NotFound();
                }

                return View(messageProperty);
            }

            // POST: VacationProperty/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var messageProperty = await _repository.FindMessagePropertyFirstOrDefaultAsync(id);
                if (messageProperty == null)
                {
                    return NotFound();
                }
                await _repository.DeleteMessagePropertyAsync(messageProperty);
                return RedirectToAction(nameof(Index));
            }
        }
    }
