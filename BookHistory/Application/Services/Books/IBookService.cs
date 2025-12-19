using BookHistory.Application.Dtos.BookDtos;

namespace BookHistory.Application.Services.Books
{
    public interface IBookService
    {
        Task<Guid> CreateAsync(CreateBookRequest request);
        Task UpdateAsync(Guid bookId, UpdateBookRequest request);
        Task<ICollection<BookResponse>> GetAsync();
    }
}
