using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxiShare.Domain.Entities;
using TaxiShare.Infrastructure.Context;

namespace TaxiShare.Application
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //serviceCollection.AddScoped<SignInManager<User>>();
            return serviceCollection;
        }
    }
}
