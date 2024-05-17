using BlazorApp.Extensions;
using BlazorApp.Extensions.ViewModels;
using BlazorApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using MudBlazor;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;


namespace BlazorApp.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ApiHttpClient httpClient;

        public IdentityService(IHttpClientFactory clientFactory, ApiHttpClient httpClient)
        {

            this.httpClient = httpClient.SetHttpClient(clientFactory.CreateClient("Identity")); 

        }
        public async Task<JwtViewModel> SignInAsync(UserSignInViewModel viewModel)
        {

           
            var response = await httpClient.PostAsync<UserSignInViewModel, JwtViewModel>("signIn", viewModel);


            return response;
        }

        public static JwtSecurityToken ReadJwt(JwtViewModel response)
        {
            return new JwtSecurityTokenHandler().ReadJwtToken(response.token);
        }

        public async Task<ClaimsPrincipal> GenerateStateFromToken(JwtSecurityToken token)
        {
            var identity = new ClaimsIdentity(token.Claims, "apiauth_type");
            var principal = new ClaimsPrincipal(identity);
            return principal;
        }
        public async Task<ClaimsPrincipal> SignUpAsync(UserSignUpViewModel viewModel)
                {

            var response = await httpClient.PostAsync<UserSignUpViewModel, JwtViewModel>("signIn", viewModel);


        var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(response.token);
        var state = GenerateStateFromToken(jwtToken);




            return await state;
    }








    }
}
