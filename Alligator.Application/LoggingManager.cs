using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Alligator.Application.Contract;
using Alligator.Persistence.Contract;

namespace Alligator.Application
{
    public class LoggingManager : ILoggingManager
    {
        private ILoggerRepository loggerRepository;

        public LoggingManager(ILoggerRepository _loggerRepository)
        {
            loggerRepository = _loggerRepository;
        }
        public async Task LogException(Exception ex, IHttpContextAccessor httpContext)
        {
            await loggerRepository.LogToDatabaseAsync(ex,httpContext);
        }
    }
}
