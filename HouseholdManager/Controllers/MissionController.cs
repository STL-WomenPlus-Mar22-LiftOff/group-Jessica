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
    public class MissionController : Controller
    {
        private readonly IQueryMembers _memberService;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Member> _userManager;

        public MissionController(ApplicationDbContext context,
                                 UserManager<Member> userManager,
                                 IQueryMembers memberService)
        {
            _context = context;
            _userManager = userManager;
            _memberService = memberService;
        }

        // GET: Mission
        public async Task<IActionResult> Index()
        {
            var household = await _memberService.GetCurrentHousehold();
            var dataQuery = _context.Missions.Where(mission => mission.HouseholdId == household.Id)
                                             .Include(t => t.Room)
                                             .Include(u => u.Member);
            return View(await dataQuery.ToListAsync());
        }

        // GET: Mission/Details/{id}
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
            return mission is null ? NotFound() 
                                   : View(new EditMissionViewModel((int)id, mission));
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
        public async Task<IActionResult> Create([Bind("Name,RoomId,Point,DueDate,MemberId")] EditMissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _memberService.GetCurrentMember();
                if (user.HouseholdId is null)
                {
                    //This is inelegant and should probably be reworked later
                    return Redirect("Household/AddOrJoinHousehold");
                }
                var household = await _memberService.GetCurrentHousehold();
                Mission mission = new Mission
                {
                    HouseholdId = (int)user.HouseholdId,
                    Name = model.Name,
                    MemberId = model.MemberId,
                    DueDate = model.DueDate,
                    RoomId = model.RoomId,
                    Point = model.Point
                };
                household.Missions.Add(mission);
                _context.Add(mission);
                _context.Update(household);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await PopulateMembers();
            ViewBag.Rooms = model.RoomId is null ? await GetRoomSelectList()
                                                 : await GetRoomSelectList((int)model.RoomId);
            return View(model);
        }

        // GET: Mission/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null || _context.Missions is null)
            {
                return NotFound();
            }
            else if (!await MissionInHousehold((int)id))
            {
                return Forbid();
            }

            var mission = await _context.Missions.FindAsync(id);
            if (mission is null)
            {
                return NotFound();
            }
            await PopulateMembers();
            ViewBag.Rooms = await GetRoomSelectList((int)id);
            return View(new EditMissionViewModel((int)id, mission));
        }

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
            else
            {
                await PopulateMembers();
                ViewBag.Rooms = await GetRoomSelectList(mission);
                return View(new EditMissionViewModel(mission));
            }
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
            return View(new EditMissionViewModel(mission));
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
                return Problem("Entity set 'ApplicationDbContext.Missions' is null.");
            }
            else if (!await MissionInHousehold((int)id))
            {
                return Forbid();
            }

            var mission = await _context.Missions.FindAsync(id);
            _context.Missions.Remove(mission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        private bool MissionExists(int id)
        {
          return _context.Missions.Any(e => e.Id == id);
        }

        /// <summary>
        /// Given a mission ID, checks if that mission is part of the user's household.  This 
        /// also functions as a null check, returning false if there is no mission with that ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if the mission is found to have the same household 
        /// ID as the user, otherwise false</returns>
        [NonAction]
        private async Task<bool> MissionInHousehold(int id)
        {
            //TODO: Figure out why this doesn't work properly
            var household = await _memberService.GetCurrentHousehold();
            if (household is null) return false;
            var found = from mission in _context.Missions
                        where mission.Id == id && mission.HouseholdId == household.Id
                        select mission.Id;
            return found.ToList().Any();
        }

        [NonAction]
        private async Task<List<Member>> PopulateMembers()
        {
            return await _memberService.GetCurrentHouseholdMembers();
        }

        [NonAction]
        private async Task<SelectList> GetRoomSelectList(Mission mission)
        {
            return await GetRoomSelectList(mission.Id);
        }

        [NonAction]
        private async Task<SelectList> GetRoomSelectList(int id)
        {
            var user = await _memberService.GetCurrentMember();
            var query = from room in _context.Rooms
                        where room.HouseholdId == user.HouseholdId
                        select new RoomListItemViewModel(room.Name, room.Icon, room.Id);
            return new SelectList(query.ToList(), "Id", "Name", id);
        }

        [NonAction]
        private async Task<SelectList> GetRoomSelectList()
        {
            var user = await _memberService.GetCurrentMember();
            var query = from room in _context.Rooms
                        where room.HouseholdId == user.HouseholdId
                        select new RoomListItemViewModel(room.Name, room.Icon, room.Id);
            return new SelectList(query.ToList(), "Id", "Name");

        }
    }
}
