using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using marketplace.DTO.Common;
using marketplace.Utilities.Const;
using System.Text.Json;
using marketplace.BackendApi.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using marketplace.Utilities.Common;

namespace marketplace.BackendApi.Middlewares
{
    public class MPExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MPExceptionHandlerMiddleware> _logger;
        private readonly IWebHostEnvironment _env;


        public MPExceptionHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IWebHostEnvironment env)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<MPExceptionHandlerMiddleware>();
            _env = env;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                LogUtils.LogException<MPExceptionHandlerMiddleware>(_env, ex, _logger, "Marketplace LogInfomation Message");
                var apiResult = DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
                await httpContext.WriteJsonResponseAsync(500, apiResult);
            }
        }
    }
}














// await HandleExceptionMessageAsync(httpContext, ex);
// await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
// private static async Task HandleExceptionMessageAsync(HttpContext httpContext, ApiResult)
// {
//     await httpContext.Response.WriteAsync("ERROR");
// }