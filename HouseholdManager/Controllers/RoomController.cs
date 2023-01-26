using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using HouseholdManager.Data.API;
using HouseholdManager.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using HouseholdManager.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using HouseholdManager.Models.ViewModels;

namespace HouseholdManager.Controllers
{
    [Authorize]
    public class RoomController : Controller, IRequestIcons, IQueryMembers
    {
        private readonly IQueryMembers _controller;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Member> _userManager;

        public RoomController(ApplicationDbContext context, 
                              UserManager<Member> userManager)
        {
            _context = context;
            _userManager = userManager;
            _controller = this;
        }

        // GET: Room
        public async Task<IActionResult> Index()
        {
            var household = await _controller.GetCurrentHousehold(_userManager, User, _context);
            var roomsQuery = from room in _context.Rooms
                             where room.HouseholdId == household.Id
                             select new EditRoomViewModel
                             {
                                 Id = room.Id,
                                 Icon = room.Icon,
                                 Name = room.Name
                             };
            return View(roomsQuery.ToList());
        }

        // GET: Room/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }
            else if (!await RoomInHousehold((int)id))
            {
                return Forbid();
            }

            var room = await _context.Rooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(new EditRoomViewModel
            {
                Id = room.Id,
                Name = room.Name,
                Icon = room.Icon,
            });
        }

        // GET: Room/Create
        public async Task<IActionResult> Create()
        {
            await PopulateIcons();
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Icon")] EditRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                var household = await _controller.GetCurrentHousehold(_userManager, User, _context);
                var room = new Room()
                {
                    Name = model.Name,
                    Icon = model.Icon,
                    Household = household,
                    HouseholdId = household.Id
                };
                household.Rooms.Add(room);
                _context.Add(room);
                _context.Update(household);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await PopulateIcons();
            return View(new EditRoomViewModel
            {
                Name = model.Name,
                Icon = model.Icon,
            });
        }

        // GET: Room/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }
            else if (!await RoomInHousehold((int)id))
            {
                return Forbid();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            await PopulateIcons();
            return View(new EditRoomViewModel
            {
                Id = room.Id,
                Name = room.Name,
                Icon = room.Icon,
            });
        }

        // POST: Room/Edit/{id}
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Icon")] EditRoomViewModel model)
        {
            var household = await _controller.GetCurrentHousehold(_userManager, User, _context);
            var room = (from rm in _context.Rooms
                        where rm.Id == id && rm.HouseholdId == household.Id
                        select rm).FirstOrDefault();
            if (room is null || id != room.Id)
            {
                return NotFound();
            } 
            else if (!await RoomInHousehold(room.Id))
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    room.Icon = model.Icon;
                    room.Name = model.Name;
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Id))
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
            await PopulateIcons();
            return View(new EditRoomViewModel
            {
                Id = room.Id,
                Name = room.Name,
                Icon = room.Icon,
            });
        }

        // GET: Room/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }
            else if (!await RoomInHousehold((int)id))
            {
                return Forbid();
            }

            var room = await _context.Rooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(new EditRoomViewModel
            {
                Id = room.Id,
                Name = room.Name,
                Icon = room.Icon,
            });
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rooms == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Rooms'  is null.");
            }
            else if (!await RoomInHousehold((int)id))
            {
                return Forbid();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        private bool RoomExists(int id)
        {
          return _context.Rooms.Any(e => e.Id == id);
        }

        [NonAction]
        private async Task<bool> RoomInHousehold(int id)
        {
            var household = await _controller.GetCurrentHousehold(_userManager, User, _context);
            if (household is null) return false;
            var found = from room in _context.Rooms
                        where room.Id == id && room.HouseholdId == household.Id
                        select room;
            return found.ToList().Any();
        }

        [NonAction]
        public async Task PopulateIcons()
        {
            IconRequestor req = new IconRequestor();
            List<Icon> icons = await req.GetIconsFromApi();
            ViewBag.Icons = icons;
        }

    }
}
