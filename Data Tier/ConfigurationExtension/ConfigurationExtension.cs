using Data_Tier.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data_Tier.ConfigurationExtension
{
    public static class ConfigurationExtension
    {
        public static IServiceCollection AddMonitoringServicesDBConfiguration(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<NoNODOCOContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString"));
            });
            return serviceCollection;
        }
    }
}
