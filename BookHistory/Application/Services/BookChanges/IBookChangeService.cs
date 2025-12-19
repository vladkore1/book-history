using BookHistory.Application.Dtos.BookChangeDtos;

namespace BookHistory.Application.Services.BookChanges
{
    public interface IBookChangeService
    {
        Task<ICollection<BookChangeResponse>> GetAsync();
        Task<ICollection<BookChangeGroupedResponse>> GetGroupedAsync();
    }
}
