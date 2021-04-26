using Microsoft.AspNetCore.Builder;
using marketplace.BackendApi.Middlewares;
using Microsoft.AspNetCore.Http;

namespace vigalileo.BackendApi.Extensions
{
    public static class MPApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseViExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MPExceptionHandlerMiddleware>();
        }
    }
}










// public static IApplicationBuilder UseViRBAC(this IApplicationBuilder app)
// {
//     return app.UseMiddleware<ViRBACMiddleware>();
// }
