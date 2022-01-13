using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //serviceCollection.AddScoped<IApplicationDbContext, ListenTogetherDbContext>();
            //serviceCollection.AddHttpClient<IEpisodesClient, EpisodesHttpClient>(opt =>
            //{
            //    opt.BaseAddress = new Uri(configuration["NetPodcastApi:BaseAddress"]);
            //});

            return serviceCollection;
        }
    }
}
