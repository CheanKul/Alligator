using System;
using System.Collections.Generic;
//using AutoMapper;
using Alligator.Application.Contract;
using Alligator.Domain.Model;
using Alligator.Persistence.Contract;

namespace Alligator.Application
{
    public class UserApplication :IUserApplication
    {
        private IUserRepository userRepository;
        //private readonly IMapper mapper;
        public UserApplication(IUserRepository _userRepository) //, IMapper _mapper)
        {
            userRepository = _userRepository;
            //mapper = _mapper;
        }

        public User Create(User User)
        {
            return userRepository.Create(User);
        }

        public List<User> Get()
        {
            return userRepository.Get();
        }

        public User Get(string id)
        {
            return userRepository.Get(id);
        }

        public User Get(string username,string password)
        {
            return userRepository.Get(username,password);
        }

        public void Remove(User UserIn)
        {
            userRepository.Remove(UserIn);
        }

        public void Remove(string id)
        {
            userRepository.Remove(id);
        }

        public void Update(string id, User UserIn)
        {
            userRepository.Update(id,UserIn);
        }
    }
}
