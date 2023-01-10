using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace BooksAssignment.Dtos
{
    public class AddBookRequestDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Author { get; set; }
        [Required]
        public int Year { get; set; }
        [MinLength(1)]
        public string? Publisher { get; set; }
        public string? Description { get; set; }
    }
}
