using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Video_Gallery.Areas.Admin.Models;
using Video_Gallery.Areas.Admin.Models.ViewModel;
using Video_Gallery.Models;

namespace Video_Gallery.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityCustomerUser> userManager;
		private SignInManager<IdentityCustomerUser> signInManager;
		private readonly ApplicationDbContext context;
		public AccountController(UserManager<IdentityCustomerUser> _usermanager, SignInManager<IdentityCustomerUser> _signInManager, ApplicationDbContext _context)
        {
			userManager = _usermanager;
			signInManager = _signInManager;
			context = _context;
		}
        [Area("Admin")]
		
		public IActionResult Login()
        {
            return View();
        }

		[Area("Admin")]
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user
					= context.Users.SingleOrDefault(e => e.UserName == model.Email);
				if (user != null)
				{
					var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
					if (result.Succeeded)
					{
						return RedirectToAction("Dashboard", "Home", new { @Areas = "Admin" });
					}
					else
					{
						ModelState.AddModelError(string.Empty, "Invalid Login Details");
						return View();
					}
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Invalid User");
					return View();
				}

			}
			else
			{

				return View();
			}

		}

		[Area("Admin")]
        public IActionResult CreateUser()
        {
            return View();
        }

        [Area("Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(CreateUserViewModel model)
	{
			if (ModelState.IsValid)
			{
				var user = new IdentityCustomerUser()
				{
					FirstName = model.FirstName,
					LastName = model.LastName,
					Email = model.Email,
					UserName = model.Email,
					PasswordHash = model.Password,
					PhoneNumber = model.PhoneNumber,
					Gender = model.Gender
				};
				IdentityResult result = await userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					ViewBag.message = "user created Sucessfully !";
					return View();
				}
				else
				{
					foreach (var er in result.Errors)
					{
						ModelState.AddModelError(string.Empty, er.Description);
					}
					return View();
				}
			}
			else
			{
				return View();
			}


		}
        public async Task<IActionResult> SingOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
