using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using marketplace.DTO.Common;
using marketplace.Utilities.Const;
using System.Text.Json;
using marketplace.BackendApi.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace marketplace.BackendApi.Middlewares
{
    public class MPExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public MPExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IWebHostEnvironment env)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                var apiResult = DefaultApiResult.GetExceptionApiResult<bool>(env, ex, false);
                await httpContext.WriteJsonResponseAsync(200, apiResult);
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