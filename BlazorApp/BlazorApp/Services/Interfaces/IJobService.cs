using BlazorApp.Extensions.ViewModels.JobsVMs;

namespace BlazorApp.Services.Interfaces
{
    public interface IJobService
    {
        Task CreateVisitAsync(CreateJobCommand command);



    }
}
