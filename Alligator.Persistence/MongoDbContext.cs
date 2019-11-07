using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Alligator.Domain.Model;

namespace Alligator.Persistence {
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IOptions<Settings> settings;
        private readonly IMongoDatabase _database = null;
        public MongoDbContext (IOptions<Settings> settings) {
            this.settings = settings;
            var client = new MongoClient (settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase (settings.Value.Database);
        }

        public IMongoCollection<Book> Books {
            get {
                return _database.GetCollection<Book> ("Book");
            }
        }

        public IMongoCollection<User> Users {
            get {
                return _database.GetCollection<User> ("User");
            }
        }
    }

    public interface IMongoDbContext {
        IMongoCollection<Book> Books { get;}
        IMongoCollection<User> Users { get;}
    }
}