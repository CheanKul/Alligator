using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Alligator.Domain.Model;
using Alligator.Persistence.Contract;
using System.Threading.Tasks;

namespace Alligator.Persistence {
    public class UserRepository : IUserRepository {
        public readonly IConfiguration configuration;
        private readonly IMongoDbContext context;

        public UserRepository (IConfiguration _configuration, IMongoDbContext context) {
            configuration = _configuration;
            this.context = context;
        }

        public List<User> Get()
        {
            return context.Users.Find(User => true).ToList();
        }

        public User Get (string id)
        {
            return context.Users.Find<User> (User => User.Id == id).FirstOrDefault ();
        }

        public User Get (string username,string password)
        {
            return context.Users.Find<User> (User => User.Username == username && User.Password == password).FirstOrDefault ();
        }

        public User Create (User User) {
            context.Users.InsertOne (User);
            return User;
        }

        public User Update (string id, User UserIn)
        {

            context.Users.ReplaceOne (User => User.Id == id, UserIn);
            return UserIn;
        }

        public User Remove (User UserIn)
        {
            context.Users.DeleteOne (User => User.Id == UserIn.Id);
            return UserIn;
        }

        public async Task Remove (string id)
        {
            await Task.FromResult(context.Users.DeleteOne (User => User.Id == id));
            
        }
    }
}