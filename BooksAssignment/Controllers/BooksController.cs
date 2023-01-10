using BooksAssignment.Data;
using BooksAssignment.Dtos;
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
            IBooksService booksService
            )
        {
            _booksService = booksService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<AddBookResponseDto>> AddNewBook ([FromBody]AddBookRequestDto request)
        {
            try
            {
                var response = await _booksService.AddNewBook(request.Title, request.Author, request.Year, request.Publisher, request.Description);
                return Ok(response);
            }
            
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetMultipleBooks([FromQuery]GetBooksRequestDto request)
        {
            var result = await _booksService.GetMultipleBooks(request.Author, request.Year, request.Title);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSingleBook([FromRoute] int id)
        {
            try
            {
                var result = await _booksService.GetSingleBook(id); 
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                await _booksService.DeleteBook(id);
            }

            catch (Exception)
            {
                return NotFound(); 
            }

            return Ok();
        }






    }
}
