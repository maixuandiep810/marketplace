using Microsoft.Extensions.DependencyInjection;
using marketplace.Services.SystemManager.User;
using marketplace.Data.Entities;
using Microsoft.AspNetCore.Identity;
using marketplace.Data.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using marketplace.Data.UnitOfWorkPattern;
using marketplace.DTO.SystemManager.User;
using marketplace.Utilities.Const;
using marketplace.DTO.Common;
using marketplace.DTO.Catalog.Product;

namespace marketplace.BackendApi.Extensions
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

        public static IServiceCollection AddMPServices(this IServiceCollection services)
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

        public static IServiceCollection AddMPValidator(this IServiceCollection services)
        {
            // USER
            services.AddTransient<IValidator<RegisterDTO>, RegisterDTOValidator>();
            services.AddTransient<IValidator<LoginDTO>, LoginDTOValidator>();
            // PRODUCT
            services.AddTransient<IValidator<CreateProductDTO>, CreateProductDTOValidator>();
            services.AddTransient<IValidator<DetailProductDTO>, DetailProductDTOValidator>();
            // COMMON
            services.AddTransient<IValidator<CreateImageDTO>, CreateImageDTOValidator>();
            return services;
        }
    }
}