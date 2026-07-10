using System.ComponentModel.DataAnnotations;

namespace SampleApi.Requests
{
    public class CreateTodoRequest
    {
        [Required]
        [StringLength(100)]

        public string Title { get; set; } = string.Empty;

        public bool IsDone { get; set; }
    }
}
