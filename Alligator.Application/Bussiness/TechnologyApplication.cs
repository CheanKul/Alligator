using Alligator.Application.Contract;
using Alligator.Domain;
using Alligator.Domain.Model;
using Alligator.Persistence.Contract;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.Application.Bussiness
{
    public class TechnologyApplication : ITechnologyApplication
    {
        private readonly ITechnologyRepository technologyRepo;
        private readonly IResponseModel responseModel;
        private readonly ICommonApplication commonApplication;

        public TechnologyApplication(ITechnologyRepository technologyRepo,IResponseModel responseModel,ICommonApplication commonApplication)
        {
            this.technologyRepo = technologyRepo;
            this.responseModel = responseModel;
            this.commonApplication = commonApplication;
        }

        public async Task<ResponseModel> GetTechnologiesAsync()
        {
            try
            {
                var li = await technologyRepo.ListTechnologyAsync();
                return responseModel.CreateResponse(HttpStatusCode.OK, "List Of Technology", Data: li);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseModel> GetTechnologyByIdAsync(string Id)
        {
            try
            {
                var li = await technologyRepo.GetTechnologyByIdAsync(Id);
                return responseModel.CreateResponse(HttpStatusCode.OK, "List Of Technology", Data: li);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseModel> UpdateTechnologyAsync(TechnologyModel technologyModel)
        {
            try
            {
                Technology technology = new Technology();
                if (technologyModel.operation == Operation.Update)
                {
                    technology = await technologyRepo.GetTechnologyByIdAsync(technologyModel.Id);
                }
                technology.Id = technologyModel.Id;
                technology.Description = technologyModel.Description;
                technology.TechnologyName = technologyModel.TechnologyName;
                technology.Image = technologyModel.Image is null ? technology.Image : await commonApplication.CreateFileAsync(technologyModel.Image, "Technology");


                switch (technologyModel.operation)
                {
                    case Operation.Add:
                        technology = await technologyRepo.AddTechnologyAsync(technology);
                        break;

                    case Operation.Update:
                        technology = await technologyRepo.UpdateTechnologyAsync(technology);
                        break;
                    case Operation.Delete:
                        technology = await technologyRepo.RemoveTechnologyAsync(technology);
                        break;
                    default:
                        break;
                }


                return responseModel.CreateResponse(HttpStatusCode.OK, $"Technology {technologyModel.operation.ToString()}ed Successfully");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
