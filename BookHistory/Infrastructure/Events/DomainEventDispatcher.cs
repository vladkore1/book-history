using BookHistory.Application.Events;
using BookHistory.Domain.Events;
using System.Reflection;

namespace BookHistory.Infrastructure.Events
{
    public sealed class DomainEventDispatcher(IServiceProvider serviceProvider) : IDomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public async Task DispatchAsync<TEvent>(TEvent domainEvent)
            where TEvent : IDomainEvent
        {
            Type handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            IEnumerable<object?> handlers = _serviceProvider.GetServices(handlerType);

            foreach (var handler in handlers)
            {
                MethodInfo? handleMethod = handlerType.GetMethod("HandleAsync");

                if (handleMethod == null || handler == null) continue;

                await (Task)handleMethod.Invoke(handler, [domainEvent])!;
            }
        }
    }
}
