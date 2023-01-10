using BooksAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksAssignment.Data
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}

