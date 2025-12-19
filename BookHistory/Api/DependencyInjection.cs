namespace BookHistory.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new()
                {
                    Title = "Book History API",
                    Version = "v1",
                    Description = "API for managing books and viewing change history"
                });
            });

            return services;
        }
    }
}
