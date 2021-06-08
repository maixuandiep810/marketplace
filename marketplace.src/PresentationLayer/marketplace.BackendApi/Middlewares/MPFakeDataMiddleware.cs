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
    public class MPFakeDataMiddleware
    {
        private readonly RequestDelegate _next;

        public MPFakeDataMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var type = 1;
            switch (type)
            {
                case 0:
                    httpContext.Items[HttpContextConst.Id_Item_Key] = "70D3215B-8677-4893-D86D-08D928933138";
                    httpContext.Items[HttpContextConst.UserName_Item_Key] = "USER MMM";
                    httpContext.Items[HttpContextConst.RoleName_Item_Key] = "Admin";
                    httpContext.Items[HttpContextConst.UserImage_Item_Key] = "";
                    break;
                case 1:
                    httpContext.Items[HttpContextConst.Id_Item_Key] = "1FAE74CF-D703-4181-B00B-EAE33E201980";
                    httpContext.Items[HttpContextConst.UserName_Item_Key] = "USER SSS";
                    httpContext.Items[HttpContextConst.RoleName_Item_Key] = "Seller";
                    httpContext.Items[HttpContextConst.UserImage_Item_Key] = "";
                    break;
                default:
                    break;
            }
            await _next.Invoke(httpContext);
        }
    }
}














// await HandleExceptionMessageAsync(httpContext, ex);
// await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
// private static async Task HandleExceptionMessageAsync(HttpContext httpContext, ApiResult)
// {
//     await httpContext.Response.WriteAsync("ERROR");
// }