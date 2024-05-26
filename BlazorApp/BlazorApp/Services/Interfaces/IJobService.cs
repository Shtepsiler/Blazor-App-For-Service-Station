using BlazorApp.Extensions.ViewModels.JobsVMs;

namespace BlazorApp.Services.Interfaces
{
    public interface IJobService
    {
        Task CreateVisitAsync(CreateJobCommand command);
        Task<JobVM> GetJobById(Guid Id);
        Task<IEnumerable<JobVMForUser>> GetJobsBYUserId(Guid UserId);
        Task<IEnumerable<JobVM>> GetAllJobs();
        Task<IEnumerable<JobVM>> GetJobByMechanicId(Guid UserId);

    }
}
