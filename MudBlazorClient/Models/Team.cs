
namespace MudBlazorClient.Models
{
    public class Team : AddTeam
    {
        public Guid Id { get; set; }
        public string? LogoPath { get; set; }
    }
}
