using BlazorApp.Extensions;
using BlazorApp.Extensions.ViewModels.PartsVMs;
using BlazorApp.Services.Interfaces;

namespace BlazorApp.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly ApiHttpClient httpClient;

        public VehicleService(IHttpClientFactory clientFactory, ApiHttpClient httpClient)
        {

            this.httpClient = httpClient.SetHttpClient(clientFactory.CreateClient("User"));

        }

        public Task<VehicleViewModel> CreateCarModelAsync(VehicleViewModel vehicleViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleViewModel>> GetCarModelsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
