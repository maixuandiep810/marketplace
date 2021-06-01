using Microsoft.AspNetCore.Builder;
using marketplace.BackendApi.Middlewares;
using Microsoft.AspNetCore.Http;

namespace marketplace.BackendApi.Extensions
{
    public static class MPApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMPExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MPExceptionHandlerMiddleware>();
        }

        public static IApplicationBuilder UseMPCommonMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MPCommonMiddleware>();
        }

        public static IApplicationBuilder UseMPAuthenticationMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MPAuthenticationMiddleware>();
        }

        public static IApplicationBuilder UseMPAuthorizationRouteMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MPAuthorizationRouteMiddleware>();
        }
    }
}










// public static IApplicationBuilder UseViRBAC(this IApplicationBuilder app)
// {
//     return app.UseMiddleware<ViRBACMiddleware>();
// }
