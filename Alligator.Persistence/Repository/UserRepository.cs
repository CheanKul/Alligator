using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Alligator.Domain.Model;
using Alligator.Persistence.Contract;

namespace Alligator.Persistence {
    public class UserRepository : IUserRepository {
        public readonly IConfiguration configuration;
        private readonly IMongoDbContext context;

        public UserRepository (IConfiguration _configuration, IMongoDbContext context) {
            configuration = _configuration;
            this.context = context;
        }

        public List<User> Get () =>
            context.Users.Find (User => true).ToList ();

        public User Get (string id) =>
            context.Users.Find<User> (User => User.Id == id).FirstOrDefault ();

        public User Get (string username,string password) =>
            context.Users.Find<User> (User => User.Username == username && User.Password == password).FirstOrDefault ();

        public User Create (User User) {
            context.Users.InsertOne (User);
            return User;
        }

        public void Update (string id, User UserIn) =>
            context.Users.ReplaceOne (User => User.Id == id, UserIn);

        public void Remove (User UserIn) =>
            context.Users.DeleteOne (User => User.Id == UserIn.Id);

        public void Remove (string id) =>
            context.Users.DeleteOne (User => User.Id == id);
    }
}