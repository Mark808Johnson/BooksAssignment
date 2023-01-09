using Microsoft.EntityFrameworkCore;

namespace BooksAssignment.Models
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

