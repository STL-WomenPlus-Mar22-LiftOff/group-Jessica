using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseholdManager.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using HouseholdManager.Models;
using Microsoft.AspNetCore.Identity;

namespace HouseholdManager.Controllers
{
    //TODO: Everything that is currently using _context.Missions needs to instead be pulling from User.Household.Missions
    [Authorize]
    public class MissionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Member> _userManager;

        public MissionController(ApplicationDbContext context,
                                 UserManager<Member> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Mission
        public async Task<IActionResult> Index()
        {
            var dataQuery = _context.Missions.Include(t => t.Room).Include(u => u.Member);
            return View(await dataQuery.ToListAsync());
        }

        // GET: Mission/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Missions == null)
            {
                return NotFound();
            }
            var household = 0;

            var mission = await _context.Missions
                .Include(t => t.Room).Include(u => u.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mission == null)
            {
                return NotFound();
            }

            return View(mission);
        }

        // GET: Mission/Create
        public IActionResult Create()
        {
            PopulateMembers();
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name");
            return View();
        }

        // POST: Mission/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MissionId,MissionName,RoomId,Point,DueDate,MemberId")] Models.Mission mission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateMembers();
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", mission.RoomId);
            return View(mission);
        }

        // GET: Mission/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Missions == null)
            {
                return NotFound();
            }

            var mission = await _context.Missions.FindAsync(id);
            if (mission == null)
            {
                return NotFound();
            }
            PopulateMembers();
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", mission.RoomId);
            return View(mission);
        }

        // POST: Mission/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MissionId,MissionName,RoomId,Point,DueDate,MemberId")] Models.Mission mission)
        {
            if (id != mission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MissionExists(mission.Id))
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
            PopulateMembers();
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", mission.RoomId);
            return View(mission);
        }

        // GET: Mission/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Missions == null)
            {
                return NotFound();
            }

            var mission = await _context.Missions
                .Include(t => t.Room).Include(u => u.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mission == null)
            {
                return NotFound();
            }

            return View(mission);
        }

        // POST: Mission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Missions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Missions'  is null.");
            }
            var mission = await _context.Missions.FindAsync(id);
            if (mission != null)
            {
                _context.Missions.Remove(mission);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //TODO: make this check against household missions
        private bool MissionExists(int id)
        {
          return _context.Missions.Any(e => e.Id == id);
        }

        //TODO: make this populate from household members
        private List<Member> PopulateMembers()
        {
            var members = new List<Member>();
            return members;
        }
    }
}
