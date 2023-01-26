using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseholdManager.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using HouseholdManager.Models;
using HouseholdManager.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using HouseholdManager.Models.ViewModels;

namespace HouseholdManager.Controllers
{
    [Authorize]
    public class MissionController : Controller, IQueryMembers
    {
        private readonly IQueryMembers _controller;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Member> _userManager;

        public MissionController(ApplicationDbContext context,
                                 UserManager<Member> userManager)
        {
            _context = context;
            _userManager = userManager;
            _controller = this;
        }

        // GET: Mission
        public async Task<IActionResult> Index()
        {
            var househould = await _controller.GetCurrentHousehold(_userManager, User, _context);
            var dataQuery = _context.Missions.Where(mission => mission.HouseholdId == househould.Id)
                                             .Include(t => t.Room)
                                             .Include(u => u.Member);
            return View(await dataQuery.ToListAsync());
        }

        // GET: Mission/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null || _context.Missions is null)
            {
                return NotFound();
            }
            else if (!await MissionInHousehold((int)id))
            {
                return Forbid();
            }
            var mission = await _context.Missions
                .Include(t => t.Room).Include(u => u.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mission is null) return NotFound();
            //TODO: View model
            return View(mission);
        }

        // GET: Mission/Create
        public async Task<IActionResult> Create()
        {
            await PopulateMembers();
            ViewBag.Rooms = await GetRoomSelectList();
            return View();
        }

        // POST: Mission/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // TODO: Make this use a view model
        public async Task<IActionResult> Create([Bind("Id,Name,RoomId,Point,DueDate,MemberId")] EditMissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await PopulateMembers();
            ViewBag.Rooms = await GetRoomSelectList(mission);
            return View(model);
        }

        // GET: Mission/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Missions == null)
            {
                return NotFound();
            }
            else if (!await MissionInHousehold((int)id))
            {
                return Forbid();
            }

            var mission = await _context.Missions.FindAsync(id);
            if (mission == null)
            {
                return NotFound();
            }
            await PopulateMembers();
            ViewBag.Rooms = await GetRoomSelectList(mission);
            // TODO: View Model
            return View(mission);
        }

        // TODO: change this to use view model
        // POST: Mission/Edit/{id}
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,RoomId,Point,DueDate,MemberId")] EditMissionViewModel model)
        {
            if (model.Id is null || _context.Missions is null)
            {
                return NotFound();
            }
            else if (!await MissionInHousehold((int)model.Id))
            {
                return Forbid();
            }
            var mission = await _context.Missions.FindAsync(model.Id);
            if (mission is null) return NotFound();
            //TODO: room Id and member Id need server-side validation as well

            if (ModelState.IsValid)
            {
                mission.Name = model.Name;
                mission.DueDate = model.DueDate;
                mission.MemberId = model.MemberId;
                mission.RoomId = model.RoomId;
                mission.Point = model.Point;
                try
                {
                    _context.Update(mission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MissionExists((int)model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            await PopulateMembers();
            ViewBag.Rooms = await GetRoomSelectList(mission);
            return View(new EditMissionViewModel
            {
                Id = model.Id,
                MemberId = model.MemberId,
                Name = model.Name,
                Point = model.Point,
                DueDate = model.DueDate,
                RoomId = model.RoomId
            });
        }

        // GET: Mission/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Missions == null)
            {
                return NotFound();
            }
            else if (!await MissionInHousehold((int)id))
            {
                return Forbid();
            }

            var mission = await _context.Missions
                .Include(t => t.Room).Include(u => u.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mission == null)
            {
                return NotFound();
            }
            // TODO: View model
            return View(mission);
        }

        // POST: Mission/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            else if (_context.Missions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Missions'  is null.");
            }
            else if (!await MissionInHousehold((int)id))
            {
                return Forbid();
            }

            var mission = await _context.Missions.FindAsync(id);
            if (mission != null)
            {
                // TODO: check that user is allowed to delete this mission
                _context.Missions.Remove(mission);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        private bool MissionExists(int id)
        {
          return _context.Missions.Any(e => e.Id == id);
        }

        [NonAction]
        private async Task<bool> MissionInHousehold(int id)
        {
            var household = await _controller.GetCurrentHousehold(_userManager, User, _context);
            if (household is null) return false;
            var found = from mission in household.Missions
                        where mission.Id == id
                        select mission.Id;
            return found.ToList().Any();
        }

        [NonAction]
        private async Task<List<Member>> PopulateMembers()
        {
            return await _controller.GetMembersInHousehold(_userManager, User, _context);
        }

        [NonAction]
        private async Task<SelectList> GetRoomSelectList(Mission mission)
        {
            var household = await _controller.GetCurrentHousehold(_userManager, User, _context);
            return new SelectList(_context.Rooms.Where(room => room.HouseholdId == household.Id), 
                                  "RoomId", 
                                  "Name", 
                                  mission.RoomId);
        }

        [NonAction]
        private async Task<SelectList> GetRoomSelectList()
        {
            var household = await _controller.GetCurrentHousehold(_userManager, User, _context);
            return new SelectList(_context.Rooms.Where(room => room.HouseholdId == household.Id),
                                  "RoomId",
                                  "Name");

        }
    }
}
