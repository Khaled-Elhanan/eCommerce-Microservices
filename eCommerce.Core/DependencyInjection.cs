using FluentValidation;
using eCommerce.Core.Services;
using eCommerce.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using eCommerce.Core.Validators;

namespace eCommerce.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<IUsersService, UserService>();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

            return services;
        }
    }
}