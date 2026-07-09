namespace SampleApi.Requests
{
    public class CreateTodoRequest
    {
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
    }
}
