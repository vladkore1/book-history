namespace BookHistory.Domain.Events
{
    public sealed record BookTitleChangedEvent(
        Guid BookId,
        string OldTitle,
        string NewTitle
    ) : IDomainEvent;
}
