using Alligator.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.Persistence.Contract
{
    public interface ITechnologyRepository
    {
        Task<Technology> AddTechnologyAsync(Technology technology);
        Task<Technology> UpdateTechnologyAsync(Technology technology);
        Task<Technology> RemoveTechnologyAsync(Technology technology);
        Task<List<Technology>> ListTechnologyAsync();
        Task<Technology> GetTechnologyByIdAsync(string id);
    }
}
