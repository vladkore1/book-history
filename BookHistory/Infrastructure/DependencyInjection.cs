using BookHistory.Application.Events;
using BookHistory.Infrastructure.Events;
using BookHistory.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BookHistory.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("Default")));

            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            return services;
        }
    }
}
