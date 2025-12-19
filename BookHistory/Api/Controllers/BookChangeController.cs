using BookHistory.Application.Dtos.BookChangeDtos;
using BookHistory.Application.Services.BookChanges;
using Microsoft.AspNetCore.Mvc;

namespace BookHistory.Api.Controllers
{
    [ApiController]
    [Route("api/book-changes")]
    public sealed class BookChangesController(IBookChangeService bookChangeService) : ControllerBase
    {
        private readonly IBookChangeService _bookChangeService = bookChangeService;

        [HttpGet]
        public async Task<ActionResult<ICollection<BookChangeResponse>>> GetAll()
        {
            var result = await _bookChangeService.GetAsync();
            return Ok(result);
        }

        [HttpGet("grouped")]
        public async Task<ActionResult<ICollection<BookChangeGroupedResponse>>> GetGrouped()
        {
            var result = await _bookChangeService.GetGroupedAsync();
            return Ok(result);
        }
    }
}
