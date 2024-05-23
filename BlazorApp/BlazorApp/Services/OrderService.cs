using BlazorApp.Components.Catalog;
using BlazorApp.Extensions;
using BlazorApp.Extensions.ViewModels.CatalogVMs;
using BlazorApp.Services.Interfaces;

namespace BlazorApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApiHttpClient httpClient;

        public OrderService(IHttpClientFactory clientFactory, ApiHttpClient httpClient)
        {

            this.httpClient = httpClient.SetHttpClient(clientFactory.CreateClient("User"));

        }

        public Task<OrderViewModel> GetOrderByIdAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }
    }
}
