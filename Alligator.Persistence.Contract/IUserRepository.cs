﻿using System;
using System.Collections.Generic;
using Alligator.Domain.Model;

namespace Alligator.Persistence.Contract
{
    public interface IUserRepository
    {
        User Create(User User);
        List<User> Get();
        User Get(string id);
        User Get(string username,string password);
        void Remove(User UserIn);
        void Remove(string id);
        void Update(string id, User UserIn);
    }
}
