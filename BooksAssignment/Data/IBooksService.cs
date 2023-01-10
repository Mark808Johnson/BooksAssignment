using BooksAssignment.Dtos;
using BooksAssignment.Models;

namespace BooksAssignment.Data
{
    public interface IBooksService
    {
        Task<AddBookResponseDto> AddNewBook(string title, string author, int year, string publisher = null, string description = null);
        Task<IEnumerable<BookDto>> GetMultipleBooks(string? author, int? year, string? publisher);
        Task<BookDto> GetSingleBook(int id);
        Task DeleteBook(int id);
    }
}
