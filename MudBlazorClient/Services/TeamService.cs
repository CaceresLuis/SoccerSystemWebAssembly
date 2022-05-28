using System.Net.Http.Json;
using System.Text;
using MudBlazorClient.Models;
using MudBlazorClient.Services.Contracts;
using Newtonsoft.Json;

namespace MudBlazorClient.Services
{
    public class TeamService : ITeamService
    {
        private readonly HttpClient _httpClient;

        public TeamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> AddTeam(AddTeam addTeam)
        {
            HttpResponseMessage? response = await _httpClient.PostAsJsonAsync("api/team", addTeam);
            if (response.IsSuccessStatusCode)
                return "Created";

            string? message = await response.Content.ReadAsStringAsync();
            string[]? messageJson = message.Split(",");
            return messageJson[3];
        }

        public async Task<List<Team>?> GetTeams()
        {
            HttpResponseMessage? response = await _httpClient.GetAsync("api/Team");
            return await response.Content.ReadFromJsonAsync<List<Team>>();
        }

        public async Task<Team> GetTeam(Guid id)
        {
            HttpResponseMessage? response = await _httpClient.GetAsync($"api/team/{id}");
            return await response.Content.ReadFromJsonAsync<Team>();
        }

        public async Task<string> UpdateTeam(Team team)
        {
            string? jsonRequest = JsonConvert.SerializeObject(team);
            StringContent? content = new(jsonRequest, Encoding.UTF8, "application/json-patch+json");
            HttpResponseMessage? response = await _httpClient.PutAsync($"api/team/{team.Id}", content);
            if (response.IsSuccessStatusCode)
                return "Updated";

            string? message = await response.Content.ReadAsStringAsync();
            string[]? messageJson = message.Split(",");
            return messageJson[3];

        }

        public async Task<string> DeleteTeam(Guid id)
        {

            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/team/{id}");
            if (response.IsSuccessStatusCode)
                return "Deleted";
            
            string? message = await response.Content.ReadAsStringAsync();
            string[]? messageJson = message.Split(",");
            return messageJson[3];

        }
    }
}
