using Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Infrastructure.Config
{
    public static class MongoConfig
    {
        public static void AddMongoConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDB") ?? "mongodb://localhost:27017";
            var databaseName = configuration["MongoDB:DatabaseName"] ?? "ClientesDB";

            services.AddSingleton<IMongoClient>(provider => new MongoClient(connectionString));
            services.AddScoped<MongoDbContext>(provider =>
            {
                var mongoClient = provider.GetRequiredService<IMongoClient>();
                return new MongoDbContext(mongoClient, databaseName);
            });
        }
    }
}
