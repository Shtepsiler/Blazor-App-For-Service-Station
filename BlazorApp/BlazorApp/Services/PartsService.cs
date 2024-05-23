using BlazorApp.Extensions;
using BlazorApp.Extensions.ViewModels.CatalogVMs;
using BlazorApp.Services.Interfaces;

namespace BlazorApp.Services
{
    public class PartsService : IPartsService
    {
        private readonly ApiHttpClient httpClient;

        public PartsService(IHttpClientFactory clientFactory, ApiHttpClient httpClient)
        {

            this.httpClient = httpClient.SetHttpClient(clientFactory.CreateClient("User"));

        }

        public Task<List<PartViewModel>> GetPartsByOrderIdAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task RemovePartFromOrderAsync(Guid orderId, Guid partId)
        {
            throw new NotImplementedException();
        }
    }
}
