using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Alligator.Application.Contract
{
    public interface ILoggingManager
    {
        Task  LogException(Exception ex, IHttpContextAccessor httpContext);
    }
}
