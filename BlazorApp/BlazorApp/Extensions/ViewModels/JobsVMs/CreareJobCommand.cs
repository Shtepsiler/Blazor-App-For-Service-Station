using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Extensions.ViewModels.JobsVMs
{
    public class CreateJobCommand
    {
        public Guid? ModelId { get; set; }

        public Guid? ClientId { get; set; }

        [Required(ErrorMessage = "Введіть дату проблеми")]
        public DateTime IssueDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Введіть опис проблеми")]
        public string Description { get; set; }
    }
}
