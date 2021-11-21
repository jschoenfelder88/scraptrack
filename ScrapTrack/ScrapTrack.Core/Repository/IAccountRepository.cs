using Microsoft.AspNetCore.Identity;
using ScrapTrack.Core.Models;
using System.Threading.Tasks;

namespace ScrapTrack.Core.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreatUserAsync(RegisterUserViewModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInViewModel signInModel);
        Task SignOUtAsync();
    }
}