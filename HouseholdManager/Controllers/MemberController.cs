using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseholdManager.Models;
using HouseholdManager.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;

namespace HouseholdManager.Controllers
{
    [Authorize(Roles = "Administrator, User")]
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MemberController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Member
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Members.Include(t => t.Household).Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Member/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            PopulateHouseholds();
            PopulateAppUsers();
            if (id == 0)
                return View(new Member());
            else
                return View(_context.Members.Find(id));
        }

        // POST: Member/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("MemberId,MemberType,MemberIcon,HouseholdId,UserName")] Member member)
        {
            if (ModelState.IsValid)
            {
                if (member.MemberId == 0)
                    _context.Add(member);
                else
                    _context.Update(member);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            PopulateHouseholds();
            PopulateAppUsers();
            return View(member);
        }


        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Members == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Member'  is null.");
            }
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [NonAction]
        public void PopulateHouseholds()
        {
            var HouseholdCollection = _context.Households.ToList();
            Household DefaultHousehold = new Household() { HouseholdId = 0, HouseholdName = "Choose a Household" };
            HouseholdCollection.Insert(0, DefaultHousehold);
            ViewBag.Households = HouseholdCollection;
        }

        [NonAction]
        public void PopulateAppUsers()
        {
            var UserCollection = _context.AppUsers.ToList();
            AppUser DefaultUser = new AppUser() { Id = "", UserName = "Choose an Identity User"};
            UserCollection.Insert(0, DefaultUser);
            ViewBag.AppUsers = UserCollection;
        }

    }
}
