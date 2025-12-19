using BookHistory.Application.Dtos.BookChangeDtos;
using BookHistory.Application.Dtos.Common;
using BookHistory.Domain.Entities;
using BookHistory.Domain.Enums;
using BookHistory.Infrastructure.Extensions;
using BookHistory.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BookHistory.Application.Services.BookChanges
{
    public sealed class BookChangeService(ApplicationDbContext db) : IBookChangeService
    {
        private readonly ApplicationDbContext _db = db;

        public async Task<PagedResult<BookChangeResponse>> GetAsync(
            BookChangePaginatedQuery query)
        {
            return await _db.BookChanges
                .ApplyFilters(query)
                .ApplyOrdering(query)
                .Select(bc => new BookChangeResponse()
                {
                    Id = bc.Id,
                    BookId = bc.BookId,
                    Description = bc.Description,
                    Type = bc.ChangeType,
                    OccurredAt = bc.OccurredAt,
                })
                .ToPagedResultAsync(query.Page, query.PageSize);
        }

        public async Task<ICollection<BookChangeGroupedResponse>> GetGroupedAsync(
            BookChangeQuery query)
        {
            // Intentionally not allowing pagination when grouping due to bad UX

            var items = await _db.BookChanges
                .ApplyFilters(query)
                .ApplyOrdering(query)
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
