using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nebula.Areas.Identity.Data;
using Nebula.VM;

namespace Nebula.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<NebulaUser> _UserManager;
        private readonly SignInManager<NebulaUser> _signInManager;
        public RegisterController(UserManager<NebulaUser> userManager, SignInManager<NebulaUser> signInManager)
        {
            _UserManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterVm user)
        {
            var newUser = new NebulaUser
            {
                Email = user.Email,
                UserName = user.Email.ToUpper(),
            };
                await _UserManager.CreateAsync(newUser, user.Password);

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Login(RegisterVm user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, true, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }


    }
}
