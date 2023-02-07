using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using HouseholdManager.Data.API;
using HouseholdManager.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using HouseholdManager.Data.Interfaces;

namespace HouseholdManager.Controllers
{
    [Authorize]
    public class RoomController : Controller, IRequestIcons
    {
        private readonly ApplicationDbContext _context;

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Room
        public async Task<IActionResult> Index()
        {
              return View(await _context.Rooms.ToListAsync());
        }

        // POST: Room/DirtHandler
        /// <summary>
        /// Processes AJAX request from dirtometerAjax.js
        /// </summary>
        /// <param name="data"></param>
        public async Task<IActionResult> DirtHandler([FromBody]Dictionary<int, int> data)
        {
            //Validation
            if (data.Count == 0) return Json("No data to update.");
            
            foreach(KeyValuePair<int, int> kvp in data)
            {
                if (kvp.Key < 0 || kvp.Value > 10 || kvp.Value < 0)
                {
                    data.Remove(kvp.Key);
                }
            }
            //TODO: Get matching rooms and stage update
            var allRooms = await _context.Rooms.ToListAsync();
            List<Room> roomsToUpdate = new List<Room>();
            foreach (Room rm in allRooms)
            {
                if (data.ContainsKey(rm.RoomId))
                {
                    if (rm.DirtLevel != data[rm.RoomId])
                    {
                        rm.DirtLevel = data[rm.RoomId];
                        roomsToUpdate.Add(rm);
                    }
                }
            }
            if (roomsToUpdate.Count == 0) return Json("No room dirt updates required.");
            //Update database
            _context.UpdateRange(roomsToUpdate);
            _context.SaveChanges();
            return Json("Room dirt values updated.");
        }

        // GET: Room/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Room/Create
        [Authorize(Roles = "Administrator,User")]
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
        [Authorize(Roles = "Administrator,User")]
        public async Task<IActionResult> Create([Bind("RoomId,Name,Icon")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await PopulateIcons();
            return View(room);
        }

        // GET: Room/Edit/5
        [Authorize(Roles = "Administrator,User")]
        public async Task<IActionResult> Edit(int? id)
        {

            await PopulateIcons();

            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,User")]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,Name,Icon")] Room room)
        {
            if (id != room.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomId))
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
            return View(room);
        }

        // GET: Room/Delete/5
        [Authorize(Roles = "Administrator,User")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,User")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rooms == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Rooms'  is null.");
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
          return _context.Rooms.Any(e => e.RoomId == id);
        }


        [NonAction]
        public async Task PopulateIcons()
        {
            IconRequestor req = new IconRequestor();
            List<Icon> icons = await req.GetIconsFromApi();
            ViewBag.Icons = icons;
        }

        [NonAction]
        private Room UpdateDirt(Room room, int value)
        {
            if (room.DirtLevel == value) return room;
            room.DirtLevel = value;
            return room;
        }

    }
}
