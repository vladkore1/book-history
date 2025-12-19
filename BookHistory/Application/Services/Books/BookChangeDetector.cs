using BookHistory.Application.Dtos.BookDtos;
using BookHistory.Domain.Entities;
using BookHistory.Domain.Events;

namespace BookHistory.Application.Services.Books
{
    public static class BookChangeDetector
    {
        public static IReadOnlyList<IDomainEvent> Detect(
        Book current,
        UpdateBookRequest updated)
        {
            var events = new List<IDomainEvent>();

            if (updated.Title != null && current.Title != updated.Title)
            {
                events.Add(new BookTitleChangedEvent(
                    current.Id,
                    current.Title,
                    updated.Title));
            }

            if (updated.Description != null &&
                current.Description != updated.Description)
            {
                events.Add(new BookDescriptionChangedEvent(current.Id));
            }

            if (updated.PublishDate.HasValue &&
                current.PublishDate != updated.PublishDate.Value)
            {
                events.Add(new BookPublishDateChangedEvent(
                    current.Id,
                    current.PublishDate,
                    updated.PublishDate.Value));
            }

            if (updated.Authors != null)
            {
                DetectAuthorChanges(
                    current.Authors,
                    updated.Authors,
                    current.Id,
                    events);
            }

            return events;
        }

        private static void DetectAuthorChanges(
            List<string> existingAuthors,
            List<string> updatedAuthors,
            Guid bookId,
            List<IDomainEvent> events)
        {
            var existing = existingAuthors
                .Select(a => a.Trim())
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var updated = updatedAuthors
                .Select(a => a.Trim())
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            foreach (var added in updated.Except(existing))
                events.Add(new AuthorAddedToBookEvent(bookId, added));

            foreach (var removed in existing.Except(updated))
                events.Add(new AuthorRemovedFromBookEvent(bookId, removed));
        }
    }
}
