using System.ComponentModel.DataAnnotations;

namespace SampleApi.Requests
{
    public class UpdateTodoRequest
    {

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
    }
}
