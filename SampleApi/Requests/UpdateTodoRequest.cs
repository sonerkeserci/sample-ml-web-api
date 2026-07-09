namespace SampleApi.Requests
{
    public class UpdateTodoRequest
    {
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
    }
}
