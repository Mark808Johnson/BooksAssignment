using System.ComponentModel.DataAnnotations;

namespace BooksAssignment.Controllers.Request
{
    public class GetBooksRequest
    {
        [MinLength(1)]
        public string? Author { get; set; }
        
        public int? Year { get; set; }
        
        [MinLength(1)]
        public string? Publisher { get; set; }
    }
}