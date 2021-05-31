using marketplace.ApiService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace marketplace.AdminApp.Extensions
{
    public static class MPServiceCollectionExtensions
    {
        public static IServiceCollection AddAspDotNetServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
        
        public static IServiceCollection AddMPServices(this IServiceCollection services)
        {
            services.AddTransient<IUserApiClient, UserApiClient>();
            return services;
        }
    }
}