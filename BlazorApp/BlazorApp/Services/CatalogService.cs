using BlazorApp.Extensions;
using BlazorApp.Services.Interfaces;

namespace BlazorApp.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ApiHttpClient httpClient;

        public CatalogService(IHttpClientFactory clientFactory, ApiHttpClient httpClient)
        {

            this.httpClient = httpClient.SetHttpClient(clientFactory.CreateClient("User"));

        }

    }
}
