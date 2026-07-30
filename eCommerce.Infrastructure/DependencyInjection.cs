using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.Services;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using eCommerce.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
          

            services.AddTransient<DapperDbContext>();

            return services;
        }
    }
}
