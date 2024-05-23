using BlazorApp.Extensions.ViewModels.CatalogVMs;

namespace BlazorApp.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderViewModel> GetOrderByIdAsync(Guid orderId);

    }
}
