using BooksAssignment.Data;

namespace BooksAssignment.Services
{
    public interface IBooksService
    {
        Task<AddBookResponse> AddNewBook(string title, string author, int year, string publisher = null, string description = null);
        Task<IEnumerable<BookDto>> GetBooks(string? author, int? year, string? publisher);
        Task<BookDto> GetBookById(string id);
        Task DeleteBookById(string id);
    }
}
