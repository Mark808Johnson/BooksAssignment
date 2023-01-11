using BooksAssignment.Models;

namespace BooksAssignment.Data
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string? Publisher { get; set; }
        public string? Description { get; set; }

        public static BookDto CreateFromBook(Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
                Publisher = book.Publisher,
                Description = book.Description,
            };
        }
    }
}

