using BookHistory.Application.Dtos.BookChangeDtos;
using BookHistory.Application.Dtos.Common;

namespace BookHistory.Application.Services.BookChanges
{
    public interface IBookChangeService
    {
        Task<PagedResult<BookChangeResponse>> GetAsync(BookChangePaginatedQuery query);
        Task<ICollection<BookChangeGroupedResponse>> GetGroupedAsync(BookChangeQuery query);
    }
}
