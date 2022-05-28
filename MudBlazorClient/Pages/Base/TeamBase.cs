using MudBlazor;
using MudBlazorClient.Models;
using Microsoft.AspNetCore.Components;
using MudBlazorClient.Services.Contracts;

namespace MudBlazorClient.Pages
{
    public class TeamBase : ComponentBase
    {
        [Inject]
        public ITeamService? TeamService { get; set; }
        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Parameter]
        public Guid Id { get; set; }
        [Parameter]
        public string? Name { get; set; }
        [Parameter]
        public string? LogoPath { get; set; }

        public string? Image { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task UpdateTeam()
        {

            Team team = new()
            {
                Id = Id,
                Name = Name,
                Image = Image
            };

            string? update = await TeamService.UpdateTeam(team);
            if (update == "Updated")
            {
                ChangePosition($"The team: <b>{team.Name}</b> has been updated", Severity.Success);
                NavigationManager.NavigateTo("/");
            }
            else
            {
                ChangePosition(update, Severity.Error);
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
