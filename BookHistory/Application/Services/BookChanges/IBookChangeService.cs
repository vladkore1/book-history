using BookHistory.Application.Dtos.BookChangeDtos;
using BookHistory.Application.Dtos.Common;

namespace BookHistory.Application.Services.BookChanges
{
    public interface IBookChangeService
    {
        Task<PagedResult<BookChangeResponse>> GetAsync(BookChangeQuery query);
        Task<ICollection<BookChangeGroupedResponse>> GetGroupedAsync();
    }
}
