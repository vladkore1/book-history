namespace BookHistory.Domain.Events
{
    public sealed record BookPublishDateChangedEvent(
        Guid BookId,
        DateOnly OldDate,
        DateOnly NewDate
    ) : IDomainEvent;
}
