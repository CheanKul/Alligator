using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alligator.Domain;
using Alligator.Domain.Model;

namespace Alligator.Application.Contract
{
    public interface IUserApplication
    {
        Task<ResponseModel> Create(User User);
        Task<ResponseModel> Get();
        Task<ResponseModel> Get(string id);
        Task<ResponseModel> Get(string username, string password);
        Task<ResponseModel> Remove(User UserIn);
        Task<ResponseModel> Remove(string id);
        Task<ResponseModel> Update(string id, User UserIn);
    }
}