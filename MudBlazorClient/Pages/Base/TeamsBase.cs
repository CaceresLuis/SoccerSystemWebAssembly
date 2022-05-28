using MudBlazor;
using MudBlazorClient.Models;
using Microsoft.AspNetCore.Components;
using MudBlazorClient.Services.Contracts;

namespace MudBlazorClient.Pages
{
    public class TeamsBase : ComponentBase
    {
        [Inject]
        public ITeamService? TeamService { get; set; }
        [Inject]
        public ISnackbar Snackbar { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<Team>? Teams { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Teams = await TeamService.GetTeams();
        }

        public async Task AddTeam()
        {

            AddTeam team = new()
            {
                Name = Name,
                Image = Logo
            };

            var create = await TeamService.AddTeam(team);
            if (create == "Created")
            {
                ChangePosition($"The team: <b>{team.Name}</b> has been created", Severity.Success);
                NavigationManager.NavigateTo("/");
            }
            else
            {
                ChangePosition(create, Severity.Error);
            }
        }

        public async Task Delete(Guid id)
        {
            string? delete = await TeamService.DeleteTeam(id);
            if (delete == "Deleted")
            {
                Team? teamRemove = Teams.FirstOrDefault(t => t.Id == id);
                Teams.Remove(teamRemove);
                ChangePosition($"The team: <b>{teamRemove.Name}</b> has been deleted", Severity.Success);
            }
            else
            {
                ChangePosition(delete, Severity.Error);
            }
        }


        private void ChangePosition(string message, Severity severity)
        {
            Snackbar.Clear();
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            Snackbar.Configuration.ShowCloseIcon = true;
            Snackbar.Add(message, severity);
        }
    }
}
