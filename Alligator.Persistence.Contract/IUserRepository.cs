using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alligator.Domain.Model;

namespace Alligator.Persistence.Contract
{
    public interface IUserRepository
    {
        User Create(User User);
        List<User> Get();
        User Get(string id);
        User Get(string username,string password);
        User Remove(User UserIn);
        Task Remove(string id);
        User Update(string id, User UserIn);
    }
}
