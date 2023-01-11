using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace BooksAssignment.Controllers.Request
{
    public class AddBookRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int? Year { get; set; } //made nullable so that Required attribute check works (otherwise returns 0)

        [MinLength(1)]
        [RegularExpression(@"^.*[a-zA-Z0-9]+.*$", ErrorMessage = "Publisher field must contain at least one alphanumeric character")] //Regex added to prevent submission of non-empty whitespace string
        public string? Publisher { get; set; }

        public string? Description { get; set; }
    }
}
