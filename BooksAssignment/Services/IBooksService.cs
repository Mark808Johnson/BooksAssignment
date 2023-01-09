using BooksAssignment.Database.Models;

namespace BooksAssignment.Services
{
    public interface IBooksService
    {
        Task<List<Book>> GetAllBooks();
        Task<List<Book>> GetBooksByAuthor(string author);
        Task<List<Book>> GetBooksByYear(int year);
        Task<List<Book>> GetBooksByPublisher (string publisher);
        Task<List<Book>> GetBooksByPublisher(string publisher, int Year);
        Task<Book> GetBookById(int id);
        Task DeleteBookById(int id);
        Task<int> AddNewBook(string title, string author, int year, string publisher = null, string description = null);
    }
}
