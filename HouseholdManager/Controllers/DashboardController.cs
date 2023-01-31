using HouseholdManager.Areas.Identity.Data;
using HouseholdManager.Data.Interfaces;
using HouseholdManager.Models;
using HouseholdManager.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HouseholdManager.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IQueryMembers _memberService;

        public DashboardController(ApplicationDbContext context,
                                   IQueryMembers memberService)
        {
            _context = context;
            _memberService = memberService;
        }

        public async Task<ActionResult> Index()
        {
            int missionCount;
            List<Mission>? missions;
            List<Member>? members;
            try
            {
                //Mission table
                missions = await _memberService.GetCurrentHouseholdMissions();
                members = await _memberService.GetCurrentHouseholdMembers();
                //TODO: check that missions is not empty?
                if (missions is null) throw new ArgumentNullException(nameof(missions));
                missionCount = missions.Count();
                ViewBag.AllMissions = missions;
            }
            catch (Exception e) when (e is KeyNotFoundException ||
                                      e is ArgumentNullException) 
            {
                return RedirectToAction("Index", "Home");
            }

            //Doughnut Chart-Missions done by Member
            var dataQuery = from mission in missions
                          //where mission.IsCompleted
                            group mission by mission.MemberId into missionsByMember
                            select missionsByMember;
            List<DashboardViewModel> dashboardData = new List<DashboardViewModel>();
            foreach (var data in dataQuery)
            {
                var member = members.Find(x => x.Id == data.Key);
                dashboardData.Add(new DashboardViewModel
                {
                    MemberIcon = member.Icon,
                    MemberName = member.DisplayName,
                    Amount = data.Sum(x => x.Point),
                    FormattedAmount = data.Sum(x => x.Point).ToString("0")
                });
            }

            ViewBag.DoughnutChartData = dashboardData;

            /*
            ViewBag.DoughnutChartData = missions
                .GroupBy(j => j.MemberId)
                .Select(k => new
                {
                    memberNameWithIcon = k.First().Member.Icon + " " + k.First().Member.DisplayName,
                    amount = k.Sum(j => j.Point),
                    formattedAmount = k.Sum(j => j.Point).ToString("0"),
                })
                .ToList();
            */

            return View();
        }
    }
}
