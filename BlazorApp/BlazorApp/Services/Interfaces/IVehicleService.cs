using BlazorApp.Extensions.ViewModels.CatalogVMs;

namespace BlazorApp.Services.Interfaces
{
    public interface IVehicleService
    {


        Task<IEnumerable<VehicleViewModel>> GetCarModelsAsync();
         Task<VehicleViewModel> CreateCarModelAsync(VehicleViewModel vehicleViewModel);
    }
}
