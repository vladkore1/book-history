using BookHistory.Application.Dtos.BookChangeDtos;
using BookHistory.Application.Dtos.Common;
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
        public async Task<ActionResult<PagedResult<BookChangeResponse>>> GetAll(
            [FromQuery] BookChangePaginatedQuery query)
        {
            var result = await _bookChangeService.GetAsync(query);
            return Ok(result);
        }

        [HttpGet("grouped")]
        public async Task<ActionResult<ICollection<BookChangeGroupedResponse>>> GetGrouped(
            [FromQuery] BookChangeQuery query)
        {
            var result = await _bookChangeService.GetGroupedAsync(query);
            return Ok(result);
        }
    }
}
