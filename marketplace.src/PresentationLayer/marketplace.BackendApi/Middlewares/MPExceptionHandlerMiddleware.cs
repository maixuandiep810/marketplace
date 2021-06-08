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
using System.Net.Mime;
using System.Text.RegularExpressions;

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
            var path = httpContext.Request.Path.ToString();
            var action = httpContext.Request.Method;
            if (Regex.IsMatch(path, UrlConst.error_get))
            {
                await _next.Invoke(httpContext);
            }

            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                LogUtils.LogException<MPExceptionHandlerMiddleware>(_env, ex, _logger, "Marketplace LogInfomation Message");
                
                var contentType = httpContext.Request.ContentType;
                if (contentType != null)
                {
                    var apiResult = DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
                    var jsonContentType = "application/json";
                    var jsonUTF8ContentType = "application/json; charset=utf-8";
                    var isApplicationJsonRequest = contentType.Equals(jsonContentType, StringComparison.OrdinalIgnoreCase) || contentType.Equals(jsonUTF8ContentType, StringComparison.OrdinalIgnoreCase);
                    if (isApplicationJsonRequest == true)
                    {
                        await httpContext.WriteJsonResponseAsync(200, apiResult);
                    }
                }
                throw ex;
                // await httpContext.WriteCodeResponseAsync(500);
                // httpContext.Response.Redirect(UrlConst.error_get);
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