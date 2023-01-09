using BooksAssignment.Database.Models;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Host;
using System.Linq;


namespace BooksAssignment.Services
{
    public class BooksService : IBooksService
    {
        private readonly BooksContext _dbContext;

        public BooksService(BooksContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public Book GetBookById(int id);
        public async Task<int> AddNewBook(string title, string author, int year, string? publisher = null, string? description = null)
        {
            var books = await _dbContext.Books
                .Where(x => x.Title == title && x.Author == author && x.Year == year)
                .ToListAsync();

            bool duplicateBook = books.Any();
           
            if (duplicateBook)
            {
                throw new HttpException(400, "Bad Request");
            }
            
            var newBook = new Book
            {
                Title = title,
                Author = author,
                Year = year,
                Publisher = publisher,
                Description = description
            };

            await _dbContext.AddAsync(newBook);
            await _dbContext.SaveChangesAsync();

            var addedBook = await _dbContext.Books.FindAsync(newBook);

            return { Id = addedBook.Id};
        }
    }
}
