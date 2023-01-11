using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;

namespace HouseholdManager.Controllers
{
    public class ContributorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContributorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contributor
        public async Task<IActionResult> Index()
        {
              return View(await _context.Contributors.ToListAsync());
        }

        // GET: Contributor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contributors == null)
            {
                return NotFound();
            }

            var contributor = await _context.Contributors
                .FirstOrDefaultAsync(m => m.AutoId == id);
            if (contributor == null)
            {
                return NotFound();
            }

            return View(contributor);
        }

        // GET: Contributor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contributor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContributorId,ContributorName,ContributorType,ContributorEmail")] Contributor contributor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contributor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contributor);
        }

        // GET: Contributor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contributor == null)
            {
                return NotFound();
            }

            var contributor = await _context.Contributor.FindAsync(id);
            if (contributor == null)
            {
                return NotFound();
            }
            return View(contributor);
        }

        // POST: Contributor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContributorId,ContributorName,Position,Email")] Contributor contributor)
        {
            if (id != contributor.AutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contributor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContributorExists(contributor.AutoId))
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
            return View(contributor);
        }

        // GET: Contributor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contributor == null)
            {
                return NotFound();
            }

            var contributor = await _context.Contributor
                .FirstOrDefaultAsync(m => m.AutoId == id);
            if (contributor == null)
            {
                return NotFound();
            }

            return View(contributor);
        }

        // POST: Contributor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contributor == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Contributor'  is null.");
            }
            var contributor = await _context.Contributor.FindAsync(id);
            if (contributor != null)
            {
                _context.Contributor.Remove(contributor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContributorExists(int id)
        {
          return _context.Contributor.Any(e => e.AutoId == id);
        }
    }
}
