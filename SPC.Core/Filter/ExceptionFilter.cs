using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SPC.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace SPC.Core.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 发生异常时进入
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                string errorMsg = string.Empty;
                if (context.Exception != null)
                {
                    errorMsg = context.Exception.Message;
                    if (context.Exception.InnerException != null)
                    {
                        errorMsg = context.Exception.InnerException.Message;
                    }
                }
                context.Result= new OkObjectResult(new BadOpResult(errorMsg));
                _logger.LogError(errorMsg);
            }
            context.ExceptionHandled = true;
        }

        /// <summary>
        /// 异步发生异常时进入
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        }
    }
}