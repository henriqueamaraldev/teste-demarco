using Domain.Entities;
using MongoDB.Driver;

namespace Infrastructure.Database
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoClient mongoClient, string databaseName)
        {
            _database = mongoClient.GetDatabase(databaseName);
        }

        public IMongoCollection<Cliente> Clientes => _database.GetCollection<Cliente>("clientes");
        public IMongoCollection<Log> Logs => _database.GetCollection<Log>("logs");
    }
}
