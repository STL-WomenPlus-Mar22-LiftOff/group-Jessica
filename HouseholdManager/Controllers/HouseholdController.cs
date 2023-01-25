using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using Microsoft.AspNetCore.Authorization;
using HouseholdManager.Areas.Identity.Data;
using HouseholdManager.Data.API;
using HouseholdManager.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using HouseholdManager.Models.ViewModels;

namespace HouseholdManager.Controllers
{
    [Authorize]
    public class HouseholdController : Controller, IRequestIcons
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Member> _userManager;

        public HouseholdController(ApplicationDbContext context,
                                  UserManager<Member> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        //GET: Household
        public IActionResult Index()
        {
            return View();
        }

        //GET: Household/AddOrJoinHousehold
        public IActionResult AddOrJoinHousehold() 
        { 
            return View();
        }

        //GET: Household/JoinExisting
        public IActionResult JoinExisting()
        {
            return View();
        }

        // GET: Household/ViewAll
        public async Task<IActionResult> ViewAll()
        {
            var dataQuery = _context.Households;
            return View(await dataQuery.ToListAsync());
        }

        // GET: Household/AddOrEdit
        public async Task<IActionResult> Edit(int id = 0)
        {
            await PopulateIcons();
            if (id == 0)
                return View(new EditHouseholdViewModel());
            else
                return View(_context.Households.Find(id));
        }

        //GET: Household/Setup
        public async Task<IActionResult> Setup()
        {
            await PopulateIcons();
            return View(new EditHouseholdViewModel());
        }

        // POST: Household/Setup
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Setup([Bind("Name,Icon")] EditHouseholdViewModel model)
        {
            if (ModelState.IsValid)
            {
                Household household = new Household()
                {
                    Name = model.Name,
                    Icon = model.Icon
                };
                //Set the current user to household administrator
                var member = await _userManager.GetUserAsync(User);
                member.MemberType = "Administrator";
                household.Members.Add(member);
                //Save to database
                _context.Add(household);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                await PopulateIcons();
                return View(model);
            }
        }

        // POST: Household/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Name,Icon")] EditHouseholdViewModel model)
        {
            if (ModelState.IsValid)
            {
                var member = await _userManager.GetUserAsync(User);
                var household = member.Household;
                if (household is null) //this is unlikely, but just in case
                {
                    household = new Household();
                    household.Name = model.Name;
                    household.Icon = model.Icon;
                    _context.Add(household);
                }
                else
                {
                    household.Name = model.Name;
                    household.Icon = model.Icon;
                    _context.Update(household);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            await PopulateIcons();
            return View(model);
        }

        //TODO: make this stop being an enormous security problem
        // POST: Household/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Households == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Households'  is null.");
            }
            var household = await _context.Households.FindAsync(id);
            if (household != null)
            {
                _context.Households.Remove(household);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
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
