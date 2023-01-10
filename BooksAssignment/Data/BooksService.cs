using BooksAssignment.Dtos;
using BooksAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Host;
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

        public async Task<AddBookResponseDto> AddNewBook(string title, string author, int year, string? publisher, string? description)
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

            return new AddBookResponseDto { Id = newBook.Id };
        }

        public async Task<IEnumerable<BookDto>> GetMultipleBooks(string? author, int? year, string? publisher)
        {
            var booksByFilter= await _dbContext.Books
                .Where(x => x.Author == author || author == null)
                .Where(x => x.Year == year || year == null)
                .Where(x => x.Publisher == publisher || publisher == null)
                .ToListAsync();

            var result = ConvertToDtoList(booksByFilter);

            return result;
        }

        public async Task<BookDto> GetSingleBook(int id)
        {
            var bookById = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (bookById == null)
            {
                throw new HttpException(404, "Not Found");
            }

            var result = BookDto.CreateFromBook(bookById);

            return result;
        }

        public async Task DeleteBook(int id)
        {
            var bookToDelete = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            
            if (bookToDelete == null)
            {
                throw new HttpException(404, "Not Found");
            }

            _dbContext.Books.Remove(bookToDelete);
            await _dbContext.SaveChangesAsync();
        }

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
