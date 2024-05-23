using BlazorApp.Extensions.ViewModels.CatalogVMs;

namespace BlazorApp.Services.Interfaces
{
    public interface IPartsService
    {
        Task<List<PartViewModel>> GetPartsByOrderIdAsync(Guid orderId);
        Task RemovePartFromOrderAsync(Guid orderId, Guid partId);
    }
}
