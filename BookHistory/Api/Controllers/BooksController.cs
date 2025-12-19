using BookHistory.Application.Dtos.BookDtos;
using BookHistory.Application.Services.Books;
using Microsoft.AspNetCore.Mvc;

namespace BookHistory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class BooksController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<BookResponse>>> GetAll()
        {
            var books = await _bookService.GetAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBookRequest request)
        {
            var bookId = await _bookService.CreateAsync(request);
            return CreatedAtAction(nameof(GetAll), new { id = bookId }, bookId);
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookRequest request)
        {
            await _bookService.UpdateAsync(id, request);
            return NoContent();
        }
    }
}
