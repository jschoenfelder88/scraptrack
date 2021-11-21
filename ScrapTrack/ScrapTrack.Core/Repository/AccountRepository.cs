 using Microsoft.AspNetCore.Identity;
using ScrapTrack.Core.Models;
using ScrapTrack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrapTrack.Core.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreatUserAsync(RegisterUserViewModel userModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserName = userModel.UserName
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync (SignInViewModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.UserName, signInModel.Password, signInModel.RememberMe, false);
            return result;
        }

        public async Task SignOUtAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
