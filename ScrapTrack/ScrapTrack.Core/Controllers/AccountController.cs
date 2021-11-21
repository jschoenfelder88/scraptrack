using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScrapTrack.Core.Models;
using ScrapTrack.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrapTrack.Core.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Register()
        {
            return PartialView("~/Views/Account/_Register.cshtml");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreatUserAsync(userModel);
                if (!result.Succeeded)
                {
                    ModelState.Clear();
                    return PartialView("~/Views/Account/_Register.cshtml", userModel);
                }
                ModelState.Clear();
                return PartialView("~/Views/Shared/_Success.cshtml");
            }
            return PartialView("~/Views/Account/_Register.cshtml", userModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel signInModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(signInModel);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOUtAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
