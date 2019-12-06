using System;
using Microsoft.AspNetCore.Http;
namespace Alligator.Domain.Model
{
    public class TechnologyModel
    {

        public Operation operation { get; set; }
        public string Id { get; set; }
        public string TechnologyName { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
