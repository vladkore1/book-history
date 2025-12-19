using BookHistory.Domain.Entities;
using BookHistory.Domain.Enums;

namespace BookHistory.Infrastructure.Persistance.Seeding
{
    public static class BookChangeSeed
    {
        public static IEnumerable<BookChange> All =>
        [
            new BookChange
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                BookId = BookSeed.HobbitId,
                ChangeType = BookChangeType.BookCreated,
                Description = "Book was created",
                OccurredAt = new DateTime(2020, 1, 1, 10, 0, 0, DateTimeKind.Utc)
            },
            new BookChange
            {
                Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                BookId = BookSeed.DuneId,
                ChangeType = BookChangeType.BookCreated,
                Description = "Book was created",
                OccurredAt = new DateTime(2021, 1, 2, 10, 0, 0, DateTimeKind.Utc)
            },
            new BookChange
            {
                Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                BookId = BookSeed.FoundationId,
                ChangeType = BookChangeType.BookCreated,
                Description = "Book was created",
                OccurredAt = new DateTime(2022, 1, 3, 10, 0, 0, DateTimeKind.Utc)
            },
            new BookChange
            {
                Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                BookId = BookSeed.CleanCodeId,
                ChangeType = BookChangeType.BookCreated,
                Description = "Book was created",
                OccurredAt = new DateTime(2024, 1, 4, 10, 0, 0, DateTimeKind.Utc)
            },
            new BookChange
            {
                Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                BookId = BookSeed.PragmaticProgrammerId,
                ChangeType = BookChangeType.BookCreated,
                Description = "Book was created",
                OccurredAt = new DateTime(2025, 1, 5, 10, 0, 0, DateTimeKind.Utc)
            }
        ];
    }
}
