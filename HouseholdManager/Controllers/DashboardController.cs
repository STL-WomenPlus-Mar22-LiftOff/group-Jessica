using HouseholdManager.Areas.Identity.Data;
using HouseholdManager.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HouseholdManager.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    //TODO: Un-break this controller
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
            //TODO: Check that user has a household and redirect if not,
            //otherwise this will throw an exception

            //Mission table
            var missions = await _memberService.GetCurrentHouseholdMissions();
            var members = await _memberService.GetCurrentHouseholdMembers();
            //TODO: check that missions is not empty?
            int missionCount = missions.Count();
            ViewBag.AllMissions = missions;

            //Doughnut Chart-Missions done by Member
            var dataQuery = from mission in missions
                                //where mission.IsCompleted
                            group mission by mission.MemberId into missionsByMember
                            select missionsByMember;
            foreach (var data in dataQuery)
            {
                var member = members.Find(x => x.Id == data.Key);
            }

            ViewBag.DoughnutChartData = 0;

            ViewBag.DoughnutChartData = missions
                .GroupBy(j => j.MemberId)
                .Select(k => new
                {
                    memberNameWithIcon = k.First().Member.Icon + " " + k.First().Member.DisplayName,
                    amount = k.Sum(j => j.Point),
                    formattedAmount = k.Sum(j => j.Point).ToString("0"),
                })
                .ToList();

            return View();
        }
    }
}
