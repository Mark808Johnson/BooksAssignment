using System.ComponentModel.DataAnnotations;

namespace BooksAssignment.Dtos
{
    public class GetBooksRequestDto
    {
        [MinLength(1)]
        public string? Author { get; set; }
        public int? Year { get; set; }
        [MinLength(1)]
        public string? Publisher { get; set; }
    }
}