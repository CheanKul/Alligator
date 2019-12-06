using System.Threading.Tasks;
using Alligator.Domain.Model;
using Alligator.Domain;
namespace Alligator.Application.Contract
{
    public interface ITechnologyApplication
    {
        Task<ResponseModel> UpdateTechnologyAsync(TechnologyModel technologyModel);
        Task<ResponseModel> GetTechnologiesAsync();
        Task<ResponseModel> GetTechnologyByIdAsync(string Id);
    }
}
