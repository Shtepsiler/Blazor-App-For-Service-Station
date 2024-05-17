using BlazorApp.Extensions.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlazorApp.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<ClaimsPrincipal> GenerateStateFromToken(JwtSecurityToken token);
        Task<ClaimsPrincipal> SignInAsync(UserSignInViewModel viewModel);
       // Task SignInWithGoogleAsync();
/*        Task<JwtViewModel> SignUpAsync(UserSignUpViewModel viewModel);
*/        Task<ClaimsPrincipal> SignUpAsync(UserSignUpViewModel viewModel);
/*        Task SingOutAsync();*/
    }
}
