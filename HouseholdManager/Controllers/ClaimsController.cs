using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HouseholdManager.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HouseholdManager.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ClaimsController : Controller
    {
        private UserManager<AppUser> userManager;
        private IAuthorizationService authService;

        public ClaimsController(UserManager<AppUser> userMgr, IAuthorizationService auth)
        {
            userManager = userMgr;
            authService = auth;
        }

        public ViewResult Index() => View(User?.Claims);

        public ViewResult Create() => View();

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create_Post(string claimType, string claimValue)
        {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);
            Claim claim = new Claim(claimType, claimValue, ClaimValueTypes.String);
            IdentityResult result = await userManager.AddClaimAsync(user, claim);

            if (result.Succeeded)
                return RedirectToAction("Index");
            else
                Errors(result);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string claimValues)
        {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);

            string[] claimValuesArray = claimValues.Split(";");
            string claimType = claimValuesArray[0], claimValue = claimValuesArray[1], claimIssuer = claimValuesArray[2];

            Claim claim = User.Claims.Where(x => x.Type == claimType && x.Value == claimValue && x.Issuer == claimIssuer).FirstOrDefault();

            IdentityResult result = await userManager.RemoveClaimAsync(user, claim);

            if (result.Succeeded)
                return RedirectToAction("Index");
            else
                Errors(result);

            return View("Index");
        }

        void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}
