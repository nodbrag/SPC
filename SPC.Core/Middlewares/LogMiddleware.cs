using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SPC.Core.Middlewares
{
    public class LogMiddleware
    {
        private readonly ILogger<LogMiddleware> _logger;
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                _logger.LogInformation("Request Url:" + context.Request.Path + Environment.NewLine
                                       + "Body:" + context.Request.Body);
                await _next.Invoke(context);
                _logger.LogInformation("Response Url:" + context.Request.Path + Environment.NewLine
                                       + "Body:" + context.Response.Body);
            }
            catch
            {
                _logger.LogError("Request Url:" + context.Request.Path + Environment.NewLine
                                 + "Body:" + context.Request.Body);
            }
        }
    }
}