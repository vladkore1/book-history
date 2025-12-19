namespace BookHistory.Domain.Events
{
    public sealed record AuthorRemovedFromBookEvent(
        Guid BookId,
        string AuthorName
    ) : IDomainEvent;
}
