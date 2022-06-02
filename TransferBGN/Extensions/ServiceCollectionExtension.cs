namespace Microsoft.Extensions.DependencyInjection
{
    using Microsoft.EntityFrameworkCore;
    using TransferBGN.Core.Contracts;
    using TransferBGN.Core.Services;
    using TransferBGN.Infrastructure.Data;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITransferService, TransferService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContexts(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}
