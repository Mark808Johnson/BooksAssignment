using BooksAssignment.Controllers.RequestModels;
using BooksAssignment.Database.Models;
using BooksAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BooksAssignment.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController : Controller
    {
        private readonly IBooksService _booksService;
        
        public BooksController(
            IBooksService bookService
            )
        {
            _booksService = bookService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> AddNewBook ([FromBody]PostNewBookRequest request)
        {
            var response = await _booksService.AddNewBook(request.Title, request.Author, request.Year, request.Publisher, request.Description);
            return Ok(response);
        }
    }
}
