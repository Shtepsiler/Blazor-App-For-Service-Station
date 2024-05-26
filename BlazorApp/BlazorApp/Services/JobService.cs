using BlazorApp.Extensions;
using BlazorApp.Extensions.ViewModels.JobsVMs;
using BlazorApp.Services.Interfaces;
using Microsoft.CodeAnalysis.CSharp;

namespace BlazorApp.Services
{
    public class JobService : IJobService
    {
        private readonly ApiHttpClient httpClient;

        public JobService(IHttpClientFactory clientFactory, ApiHttpClient httpClient)
        {

            this.httpClient = httpClient.SetHttpClient(clientFactory.CreateClient("Job"));

        }

        public async Task CreateVisitAsync(CreateJobCommand command)
        {
            var parameters = new Dictionary<string, string> { };

            await httpClient.PostAsync("", parameters,command);
        }

        public async Task<IEnumerable<JobVM>> GetAllJobs()
        {
           return await httpClient.GetAsync<IEnumerable<JobVM>>("");
        }

        public async Task<JobVM> GetJobById(Guid Id)
        {
            return await httpClient.GetAsync<JobVM>(Id.ToString());
        }

        public async Task<IEnumerable<JobVM>> GetJobByMechanicId(Guid MechanicId)
        {
            var parameters = new Dictionary<string, string> { { "Id", $"{MechanicId.ToString()}" } };

            return await httpClient.GetAsync<IEnumerable<JobVM>>("GetJobByMechanicId", parameters);
        }

/*        public async Task<IEnumerable<JobVM>> GetJobsBYUserId(Guid UserId)
        {
            var parameters = new Dictionary<string, string> { {"Id",$"{UserId.ToString()}" } };

            return await httpClient.GetAsync<IEnumerable<JobVM>>("GetJobsBYUserId", parameters);
        }*/

        public async Task<IEnumerable<JobVMForUser>> GetJobsBYUserId(Guid UserId)
        {
            var parameters = new Dictionary<string, string> { { "Id", $"{UserId.ToString()}" } };

            return await httpClient.GetAsync<IEnumerable<JobVMForUser>>("GetJobsBYUserId", parameters);
        }
    }
}
