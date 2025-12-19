using BookHistory.Domain.Events;

namespace BookHistory.Application.Events
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync<TEvent>(TEvent domainEvent)
            where TEvent : IDomainEvent;
    }
}
