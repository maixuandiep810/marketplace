using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using marketplace.DTOs.Common;
using marketplace.Utilities.Const;
using marketplace.Utilities.Exceptions;
using System.Text.Json;
using marketplace.BackendApi.Extensions;

namespace marketplace.BackendApi.Middlewares
{
    public class MPExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public MPExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (MPException ex)
            {
                var result = new ApiResult<bool>(false);
                result.SetResult((int)ex.ApiCode, false, false, ex.Message);
                await httpContext.WriteJsonResponseAsync(200, result);
            }
            catch (Exception ex)
            {
                var result = new ApiResult<bool>(false);
                result.SetResult((int)ApiResultConst.CODE.CLIENT_ERROR, false, false, ex.Message);
                await httpContext.WriteJsonResponseAsync(200, result);
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