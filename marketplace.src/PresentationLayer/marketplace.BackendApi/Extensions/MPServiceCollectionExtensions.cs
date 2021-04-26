using Microsoft.Extensions.DependencyInjection;
using marketplace.Services.System.User;
using marketplace.Data.Entities;
using Microsoft.AspNetCore.Identity;
using marketplace.Data.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using marketplace.Data.UnitOfWorkPattern;
using marketplace.DTOs.System.Users;
using marketplace.Utilities.Const;

namespace vigalileo.BackendApi.Extensions
{
    public static class MPServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<marketplaceDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(SystemConst.MAIN_CONNECTION_STRING)));

            services.AddIdentity<TaiKhoan, VaiTro>()
                .AddEntityFrameworkStores<marketplaceDbContext>()
                .AddDefaultTokenProviders();
            return services;
        }

        public static IServiceCollection AddViServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddTransient<UserManager<TaiKhoan>, UserManager<TaiKhoan>>();
            services.AddTransient<SignInManager<TaiKhoan>, SignInManager<TaiKhoan>>();
            services.AddTransient<RoleManager<VaiTro>, RoleManager<VaiTro>>();
            return services;
        }

        public static IServiceCollection AddViValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<RegisterRequest>, RegisterRequestValidator>();
            services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();
            return services;
        }
    }
}