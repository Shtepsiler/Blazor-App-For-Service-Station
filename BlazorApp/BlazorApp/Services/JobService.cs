using BlazorApp.Extensions;
using BlazorApp.Extensions.ViewModels.JobsVMs;
using BlazorApp.Services.Interfaces;

namespace BlazorApp.Services
{
    public class JobService : IJobService
    {
        private readonly ApiHttpClient httpClient;

        public JobService(IHttpClientFactory clientFactory, ApiHttpClient httpClient)
        {

            this.httpClient = httpClient.SetHttpClient(clientFactory.CreateClient("User"));

        }

        public Task CreateVisitAsync(CreateJobCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
