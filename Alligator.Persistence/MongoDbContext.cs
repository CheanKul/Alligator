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


        public IMongoCollection<User> Users {
            get {
                return _database.GetCollection<User> (nameof(Users));
            }
        }

        public IMongoCollection<Technology> Technologies
        {
            get
            {
                return _database.GetCollection<Technology>(nameof(Technologies));
            }
        }
    }

    public interface IMongoDbContext {
        IMongoCollection<User> Users { get;}
        IMongoCollection<Technology> Technologies { get; }
    }
}