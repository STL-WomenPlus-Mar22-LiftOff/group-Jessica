using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using System.Text.Json;

namespace HouseholdManager.Controllers
{
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;

        private const string OpenEmojiApiKey = "2f3055e94632aca65cac6bbe8c8488c414cc9a27";

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Room
        public async Task<IActionResult> Index()
        {
              return View(await _context.Rooms.ToListAsync());
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,Name,Icon")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Room/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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
            return View(room);
        }

        // GET: Room/Delete/5
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

        private bool RoomExists(int id)
        {
          return _context.Rooms.Any(e => e.RoomId == id);
        }

        /// <summary>
        /// Helper method for GetIconsFromApi().
        /// </summary>
        /// <param name="path"></param>
        /// <returns>A list of icons, if successful</returns>
        /// <exception cref="JsonException"></exception>
        private async Task<List<Icon>> DeserializeIconData(string path)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(path))
                {
                    string rawData = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    return JsonSerializer.Deserialize<List<Icon>>(rawData, options) 
                           ?? throw new BadHttpRequestException($"Unable to load icons - null or bad JSON data retrieved from OpenEmoji API.  Request path: {path}");
                }
            }
        }

        /// <summary>
        /// Gets a list of all available icons matching the search term from OpenEmoji's API
        /// </summary>
        /// <param name="searchTerm"></param>
        public async Task<List<Icon>> GetIconsFromApi(string searchTerm = "")
        {
            string path;
            if (string.IsNullOrEmpty(searchTerm))
            {
                path = $"https://emoji-api.com/emojis?access_key={OpenEmojiApiKey}";
            }
            else
            {
                path = $"https://emoji-api.com/emojis?search={searchTerm}&access_key={OpenEmojiApiKey}";
            }

            try
            {
                var iconList = await DeserializeIconData(path);
                return iconList;
            }
            catch (BadHttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return new List<Icon>();
            }
        }
        
    }
}
