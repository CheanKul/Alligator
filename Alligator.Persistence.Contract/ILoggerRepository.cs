using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Alligator.Persistence.Contract
{
    public interface ILoggerRepository
    {
       // void LogToDatabase(Exception ex);
       Task LogToDatabaseAsync(Exception ex, IHttpContextAccessor httpContext);
    }
}
