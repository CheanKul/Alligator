using Alligator.Domain.Model;
using Alligator.Persistence.Contract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.Persistence.Repository
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly IMongoDbContext context;

        public TechnologyRepository(IMongoDbContext context)
        {
            this.context = context;
        }


        public async Task<Technology> AddTechnologyAsync(Technology technology)
        {
            try
            {
                await context.Technologies.InsertOneAsync(technology);
                return technology;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Technology> GetTechnologyByIdAsync(string id)
        {
            try
            {
                var li = await context.Technologies.FindAsync<Technology>(a => a.Id.Equals(id));
                return await li.FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Technology>> ListTechnologyAsync()
        {
            try
            {
                return await context.Technologies.AsQueryable().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Technology> RemoveTechnologyAsync(Technology technology)
        {
            try
            {
                await context.Technologies.DeleteOneAsync<Technology>(a => a.Id.Equals(technology.Id));
                return technology;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Technology> UpdateTechnologyAsync(Technology technology)
        {
            try
            {
                await context.Technologies.ReplaceOneAsync<Technology>(a => a.Id.Equals(technology.Id), technology);
                return technology;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
