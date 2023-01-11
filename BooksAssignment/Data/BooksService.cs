using BooksAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace BooksAssignment.Data
{
    public class BooksService : IBooksService
    {
        private readonly BooksContext _dbContext;

        public BooksService(BooksContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddBookResponse> AddNewBook(string title, string author, int year, string? publisher, string? description)
        {
            var books = await _dbContext.Books
                .Where(x => x.Title == title && x.Author == author && x.Year == year)
                .ToListAsync();
                
            bool duplicateBook = books.Any();

            if (duplicateBook)
            {
                throw new Exception("Cannot add requested book as duplicate has been found in the database");
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

            var result = new AddBookResponse { Id = newBook.Id};


            return result;
        }

        public async Task<IEnumerable<BookDto>> GetBooks(string? author, int? year, string? publisher)
        {
            var booksByFilter= await _dbContext.Books
                .Where(x => x.Author == author || author == null)
                .Where(x => x.Year == year || year == null)
                .Where(x => x.Publisher == publisher || publisher == null)
                .ToListAsync();

            var result = ConvertToDtoList(booksByFilter);

            return result;
        }

        public async Task<BookDto> GetBookById(string id)
        {
            var isIdInteger = int.TryParse(id, out int idInteger);

            if (!isIdInteger)
            {
                throw new Exception("Id must be an integer number");
            }

            var bookById = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == idInteger);

            if (bookById == null)
            {
                throw new Exception("Book with given Id not found in database");
            }

            var result = BookDto.CreateFromBook(bookById);

            return result;
        }

        public async Task DeleteBookById(string id)
        {
            var isIdInteger = int.TryParse(id, out int idInteger);

            if (!isIdInteger)
            {
                throw new Exception("Id must be provided as a whole number");
            }

            var bookToDelete = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == idInteger);
            
            if (bookToDelete == null)
            {
                throw new Exception("Book with given Id not found in database");
            }

            _dbContext.Books.Remove(bookToDelete);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Helper function to convert list of Book class entities to corresponding Dto List
        /// </summary>
        public List<BookDto> ConvertToDtoList(List<Book> booksList)
        {
            var bookDtoList = new List<BookDto>();

            foreach (var book in booksList)
            {
                var bookDto = BookDto.CreateFromBook(book);
                bookDtoList.Add(bookDto);
            }

            return bookDtoList;
        }
    }
}
