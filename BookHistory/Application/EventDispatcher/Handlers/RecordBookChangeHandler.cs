using BookHistory.Domain.Entities;
using BookHistory.Domain.Enums;
using BookHistory.Domain.Events;
using BookHistory.Infrastructure.Persistance;

namespace BookHistory.Application.Events.Handlers
{
    public sealed class RecordBookChangeHandler(ApplicationDbContext db) :
        IDomainEventHandler<BookCreatedEvent>,
        IDomainEventHandler<BookTitleChangedEvent>,
        IDomainEventHandler<BookDescriptionChangedEvent>,
        IDomainEventHandler<BookPublishDateChangedEvent>,
        IDomainEventHandler<AuthorAddedToBookEvent>,
        IDomainEventHandler<AuthorRemovedFromBookEvent>

    {
        private readonly ApplicationDbContext _db = db;

        public Task HandleAsync(BookCreatedEvent e)
            => AddChangeAsync(
                e.BookId,
                BookChangeType.BookCreated,
                $"Book \"{e.Title}\" was created");

        public Task HandleAsync(BookTitleChangedEvent e)
            => AddChangeAsync(
                e.BookId,
                BookChangeType.TitleChanged,
                $"Title changed from \"{e.OldTitle}\" to \"{e.NewTitle}\"");

        public Task HandleAsync(BookDescriptionChangedEvent e)
            => AddChangeAsync(
                e.BookId,
                BookChangeType.DescriptionChanged,
                "Description was updated");

        public Task HandleAsync(BookPublishDateChangedEvent e)
            => AddChangeAsync(
                e.BookId,
                BookChangeType.PublishDateChanged,
                $"Publish date changed from {e.OldDate:d} to {e.NewDate:d}");

        public Task HandleAsync(AuthorAddedToBookEvent e)
            => AddChangeAsync(
                e.BookId,
                BookChangeType.AuthorAdded,
                $"Author \"{e.AuthorName}\" was added");

        public Task HandleAsync(AuthorRemovedFromBookEvent e)
            => AddChangeAsync(
                e.BookId,
                BookChangeType.AuthorDeleted,
                $"Author \"{e.AuthorName}\" was removed");

        private async Task AddChangeAsync(
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
