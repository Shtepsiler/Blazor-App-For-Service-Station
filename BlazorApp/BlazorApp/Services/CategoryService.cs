using BlazorApp.Extensions;
using BlazorApp.Services.Interfaces;

namespace BlazorApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApiHttpClient httpClient;

        public CategoryService(IHttpClientFactory clientFactory, ApiHttpClient httpClient)
        {

            this.httpClient = httpClient.SetHttpClient(clientFactory.CreateClient("User"));

        }

    }
}
