namespace LeaveManagement.Application.Responses
{
    public class BaseRequestResponse
    {
        public Guid Id { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
