using BookHistory.Application.Dtos.BookChangeDtos;
using BookHistory.Domain.Entities;
using BookHistory.Domain.Enums;
using BookHistory.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BookHistory.Application.Services.BookChanges
{
    public sealed class BookChangeService(ApplicationDbContext db) : IBookChangeService
    {
        private readonly ApplicationDbContext _db = db;

        public async Task<ICollection<BookChangeResponse>> GetAsync()
        {
            return await _db.BookChanges
                .Select(bc => new BookChangeResponse()
                {
                    Id = bc.Id,
                    BookId = bc.BookId,
                    Description = bc.Description,
                    Type = bc.ChangeType,
                    OccurredAt = bc.OccurredAt,
                })
                .ToListAsync();
        }

        public async Task<ICollection<BookChangeGroupedResponse>> GetGroupedAsync()
        {
            var items = await _db.BookChanges
                .Select(bc => new BookChangeResponse()
                {
                    Id = bc.Id,
                    BookId = bc.BookId,
                    Description = bc.Description,
                    Type = bc.ChangeType,
                    OccurredAt = bc.OccurredAt,
                })
                .ToListAsync();

            return items
                .GroupBy(bc => DateOnly.FromDateTime(bc.OccurredAt))
                .Select(g => new BookChangeGroupedResponse()
                {
                    Date = g.Key,
                    Changes = g.ToList(),
                })
                .ToList();
        }

        public async Task AddChangeAsync(
            Guid bookId,
            BookChangeType type,
            string description)
        {
            var bookChange = new BookChange()
            {
                BookId = bookId,
                OccurredAt = DateTime.UtcNow,
                ChangeType = type,
                Description = description

            };
            _db.BookChanges.Add(bookChange);
            await _db.SaveChangesAsync();
        }
    }
}
