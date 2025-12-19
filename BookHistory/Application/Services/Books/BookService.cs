using BookHistory.Application.Dtos.BookDtos;
using BookHistory.Application.Events;
using BookHistory.Domain.Entities;
using BookHistory.Domain.Events;
using BookHistory.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BookHistory.Application.Services.Books
{
    public sealed class BookService(
        ApplicationDbContext db,
        IDomainEventDispatcher dispatcher) : IBookService
    {
        private readonly ApplicationDbContext _db = db;
        private readonly IDomainEventDispatcher _dispatcher = dispatcher;

        public async Task<Guid> CreateAsync(CreateBookRequest request)
        {
            var book = new Book()
            {
                Title = request.Title,
                Description = request.Description,
                PublishDate = request.PublishDate,
                Authors = request.Authors,
            };

            _db.Books.Add(book);
            await _db.SaveChangesAsync();
            await _dispatcher.DispatchAsync(new BookCreatedEvent(book.Id, book.Title));
            return book.Id;
        }

        public async Task UpdateAsync(Guid bookId, UpdateBookRequest request)
        {
            var book = await _db.Books
                .FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null)
                throw new Exception("Book not found");

            var events = BookChangeDetector.Detect(book, request);
            if (events.Count == 0)
                return;

            if (request.Title != null)
                book.Title = request.Title;

            if (request.Description != null)
                book.Description = request.Description;

            if (request.PublishDate.HasValue)
                book.PublishDate = request.PublishDate.Value;

            if (request.Authors != null)
            {
                book.Authors = request.Authors
                    .Select(a => a.Trim())
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();
            }

            await _db.SaveChangesAsync();

            foreach (var e in events)
                await _dispatcher.DispatchAsync(e);
        }

        public async Task<ICollection<BookResponse>> GetAsync()
        {
            return await _db.Books
                .Select(b => new BookResponse()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    PublishDate = b.PublishDate,
                    Authors = b.Authors,
                })
                .ToListAsync();
        }
    }
}
