using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Ciber.Configure.Exception
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        /// <param name="logger"></param>
        public HttpGlobalExceptionFilter(ILogger<HttpGlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// System exception
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var developerMessage = exception.Message + "\r\n" + exception.StackTrace;
            while (exception.InnerException != null)
            {
                developerMessage += "\r\n--------------------------------------------------\r\n";
                exception = exception.InnerException;
                developerMessage += (exception.Message + "\r\n" + exception.StackTrace);
            }

            _logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                developerMessage);
            Serilog.Log.Logger.Error(developerMessage);

            context.ExceptionHandled = true;
        }
    }
}
