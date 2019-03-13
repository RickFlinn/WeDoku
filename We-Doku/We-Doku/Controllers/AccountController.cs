using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using We_Doku.Models;
using We_Doku.Models.ViewModels;

namespace We_Doku.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser rvm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {

                    UserName = rvm.Email,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,

                };

                var result = await _userManager.CreateAsync(user, rvm.Password);
                if (result.Succeeded)
                {
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimTypes.Email);
                    List<Claim> claims = new List<Claim> { fullNameClaim, emailClaim };

                    await _userManager.AddClaimsAsync(user, claims);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    //TODO: Redirect to a place
                    return LocalRedirect("~/Game");
                }
            }
            return View(rvm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUser lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {
                    // redirect 
                    return LocalRedirect("~/Game");
                }
            }

            ModelState.TryAddModelError(string.Empty, "Invalid Login Attempt");
            return View(lvm);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

     

     
    }
}