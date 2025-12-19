using BookHistory.Application.Dtos.BookDtos;
using BookHistory.Application.Dtos.Common;

namespace BookHistory.Application.Services.Books
{
    public interface IBookService
    {
        Task<Guid> CreateAsync(CreateBookRequest request);
        Task UpdateAsync(Guid bookId, UpdateBookRequest request);
        Task<PagedResult<BookResponse>> GetAsync(BookQuery query);
    }
}
