using BlazorApp.Components.Account.Pages.Manage;
using BlazorApp.Extensions;
using BlazorApp.Extensions.ViewModels.CatalogVMs;
using BlazorApp.Extensions.ViewModels.IdentityVMs;
using BlazorApp.Services.Interfaces;

namespace BlazorApp.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly ApiHttpClient httpClient;

        public VehicleService(IHttpClientFactory clientFactory, ApiHttpClient httpClient)
        {

            this.httpClient = httpClient.SetHttpClient(clientFactory.CreateClient("Vehicle"));

        }

        public async Task<VehicleViewModel> CreateCarModelAsync(VehicleViewModel vehicleViewModel)
        {
            var parameters = new Dictionary<string, string>{ };
            return await httpClient.PostAsync<VehicleViewModel,VehicleViewModel>("", vehicleViewModel);
        }

        public async Task<IEnumerable<VehicleViewModel>> GetCarModelsAsync()
        {
            return await httpClient.GetAsync<IEnumerable<VehicleViewModel>>("");
        }
    }
}
