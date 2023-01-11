using BooksAssignment.Dtos;
using BooksAssignment.Models;

namespace BooksAssignment.Data
{
    public interface IBooksService
    {
        Task<AddBookResponseDto> AddNewBook(string title, string author, int year, string publisher = null, string description = null);
        Task<IEnumerable<BookDto>> GetBooks(string? author, int? year, string? publisher);
        Task<BookDto> GetBookById(string id);
        Task DeleteBookById(string id);
    }
}
