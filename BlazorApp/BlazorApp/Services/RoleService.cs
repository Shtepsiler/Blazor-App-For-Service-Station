using BlazorApp.Extensions;
using BlazorApp.Services.Interfaces;

namespace BlazorApp.Services
{
    public class RoleService : IRoleService
    {
        private readonly ApiHttpClient httpClient;

        public RoleService(IHttpClientFactory clientFactory, ApiHttpClient httpClient)
        {

            this.httpClient = httpClient.SetHttpClient(clientFactory.CreateClient("User"));

        }

    }
}
