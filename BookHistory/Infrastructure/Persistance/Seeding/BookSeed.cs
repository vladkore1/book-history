using BookHistory.Domain.Entities;

namespace BookHistory.Infrastructure.Persistance.Seeding
{
    public static class BookSeed
    {
        public static readonly Guid HobbitId =
            Guid.Parse("11111111-1111-1111-1111-111111111111");

        public static readonly Guid DuneId =
            Guid.Parse("22222222-2222-2222-2222-222222222222");

        public static readonly Guid FoundationId =
            Guid.Parse("33333333-3333-3333-3333-333333333333");

        public static readonly Guid CleanCodeId =
            Guid.Parse("44444444-4444-4444-4444-444444444444");

        public static readonly Guid PragmaticProgrammerId =
            Guid.Parse("55555555-5555-5555-5555-555555555555");

        public static IEnumerable<Book> All =>
        [
            new Book
            {
                Id = HobbitId,
                Title = "The Hobbit",
                Description = "A fantasy novel",
                PublishDate = new DateOnly(1937, 9, 21),
                Authors = ["J.R.R. Tolkien"]
            },
            new Book
            {
                Id = DuneId,
                Title = "Dune",
                Description = "Science fiction epic",
                PublishDate = new DateOnly(1965, 8, 1),
                Authors = ["Frank Herbert"]
            },
            new Book
            {
                Id = FoundationId,
                Title = "Foundation",
                Description = "Sci-fi about the fall of empires",
                PublishDate = new DateOnly(1951, 6, 1),
                Authors = ["Isaac Asimov"]
            },
            new Book
            {
                Id = CleanCodeId,
                Title = "Clean Code",
                Description = "A handbook of agile software craftsmanship",
                PublishDate = new DateOnly(2008, 8, 1),
                Authors = ["Robert C. Martin"]
            },
            new Book
            {
                Id = PragmaticProgrammerId,
                Title = "The Pragmatic Programmer",
                Description = "Journey to mastery",
                PublishDate = new DateOnly(1999, 10, 30),
                Authors = ["Andrew Hunt", "David Thomas"]
            }
        ];
    }
}
