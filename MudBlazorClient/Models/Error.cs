namespace MudBlazorClient.Models
{
    public class Error
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string State { get; set; }
    }
}
