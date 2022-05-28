using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MudBlazorClient.Models
{
    public class AddTeam
    {
        [Required]
        [StringLength(8, ErrorMessage = "Name length can't be more than 50.")]
        public string? Name { get; set; }
        public string? Image { get; set; }
    }
}
