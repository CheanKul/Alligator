using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Alligator.Persistence.Contract;

namespace Alligator.Persistence
{
    /// <summary>
    /// Need to refractor this Method
    /// </summary>
    public class LoggerRepository : ILoggerRepository
    {
        private readonly AppDBContext _context;

        public LoggerRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task LogToDatabaseAsync(Exception ex, IHttpContextAccessor ctxObject)
        {
            try
            {
                if (ex != null)
                {
                    string strReqURL = ctxObject.HttpContext.Request.Host.Host; 
                    string strReqQS = ctxObject.HttpContext.Request.QueryString.ToString();
                    string strServerName = ctxObject.HttpContext.Request.Headers["Referer"].ToString(); 
                    string strUserAgent = ctxObject.HttpContext.Request.Headers["User-Agent"].ToString(); 
                    string strUserIP = ctxObject.HttpContext.Connection.RemoteIpAddress.ToString();
                    string strUserAuthen = ctxObject.HttpContext.User.Identity.IsAuthenticated.ToString(); 
                    string strUserName =(ctxObject.HttpContext.User.Identity.Name != null) ? ctxObject.HttpContext.User.Identity.Name : string.Empty;
                    string strMessage = ex.Message;
                    string strSource = ex.Source;
                    string strTargetSite = ex.TargetSite.ToString();
                    string strStackTrace = ex.StackTrace;
                    
                    FormattableString queryString = $"call csp_LogExceptionToDB( {strSource},{DateTime.Now} ,{strMessage} ,{strReqQS} ,{strTargetSite} ,{strStackTrace} ,{strServerName} ,{strReqURL} ,{strUserAgent} ,{strUserIP} ,{strUserAuthen},{strUserName}) ";

                    var query = await _context.Database.ExecuteSqlInterpolatedAsync(queryString);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
