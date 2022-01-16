using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxiShare.Infrastructure.Context;

namespace TaxiShare.Infrastructure
{
    public static class ServiceCollectionsExtensions
    {
        private const string ConnectionString = "Default";
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionString);
            serviceCollection.AddNpgsql<TaxiShareDbContext>(connectionString);

            return serviceCollection;
        }
    }
}
