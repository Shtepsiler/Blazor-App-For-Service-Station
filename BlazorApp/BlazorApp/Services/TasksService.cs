using BlazorApp.Extensions;
using BlazorApp.Extensions.ViewModels.JobsVMs;
using BlazorApp.Services.Interfaces;

namespace BlazorApp.Services
{
    public class TasksService : ITasksService
    {
        private readonly ApiHttpClient httpClient;

        public TasksService(IHttpClientFactory clientFactory, ApiHttpClient httpClient)
        {

            this.httpClient = httpClient.SetHttpClient(clientFactory.CreateClient("User"));

        }

        public Task AddTask(TaskViewModel taskViewModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTask(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskViewModel> GetTask(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskViewModel>> GetTasks()
        {
            return Task.FromResult( new List<TaskViewModel>().AsEnumerable());
        }

        public Task<IEnumerable<TaskViewModel>> GetTasksByMechanic(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTask(TaskViewModel taskViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
