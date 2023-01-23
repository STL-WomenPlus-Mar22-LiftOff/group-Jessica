using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HouseholdManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace HouseholdManager.Controllers
{

    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;
        private IPasswordHasher<AppUser> passwordHasher;
        private IPasswordValidator<AppUser> passwordValidator;
        private IUserValidator<AppUser> userValidator;

        public AdminController(UserManager<AppUser> usrMgr, IPasswordHasher<AppUser> passwordHash, IPasswordValidator<AppUser> passwordVal, IUserValidator<AppUser> userValid)
        {
            userManager = usrMgr;
            passwordHasher = passwordHash;
            passwordValidator = passwordVal;
            userValidator = userValid;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            
            return View(userManager.Users);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AdminIndex()
        {
            return View("AdminWelcome");
        }

        [AllowAnonymous]
        public ViewResult Create() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = user.Email,
                    Email = user.Email,
                    Age = user.Age,
                    FirstName= user.FirstName,
                    LastName= user.LastName
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);

                if (result.Succeeded)
                    return Redirect("/Welcome/Index");
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(string id, string email, string password, int? age, string? firstName, string? lastName)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult validEmail = null;
                if (!string.IsNullOrEmpty(email))
                {
                    validEmail = await userValidator.ValidateAsync(userManager, user);
                    if (validEmail.Succeeded)
                        user.Email = email;
                    else
                        Errors(validEmail);
                }
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, password);
                    if (validPass.Succeeded)
                        user.PasswordHash = passwordHasher.HashPassword(user, password);
                    else
                        Errors(validPass);
                }
                else
                    ModelState.AddModelError("", "Password cannot be empty");

                user.Age = age;
                user.FirstName = firstName;
                user.LastName = lastName;

                if (validEmail != null && validPass != null && validEmail.Succeeded && validPass.Succeeded)
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");

            return View(user);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", userManager.Users);
        }
    }
}