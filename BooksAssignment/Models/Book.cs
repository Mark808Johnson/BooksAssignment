namespace BooksAssignment.Models
{
    //domain object representation
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string? Publisher { get; set; }
        public string? Description { get; set; }
    }
}
