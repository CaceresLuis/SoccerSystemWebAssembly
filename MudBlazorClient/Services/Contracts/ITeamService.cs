using MudBlazorClient.Models;

namespace MudBlazorClient.Services.Contracts
{
    public interface ITeamService
    {
        Task<string> AddTeam(AddTeam addTeam);
        Task<string> DeleteTeam(Guid id);
        Task<Team> GetTeam(Guid id);
        Task<List<Team>?> GetTeams();
        Task<string> UpdateTeam(Team team);
    }
}
