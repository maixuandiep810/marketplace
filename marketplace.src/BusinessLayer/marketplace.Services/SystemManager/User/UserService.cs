using marketplace.Data.UnitOfWorkPattern;
using marketplace.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using marketplace.DTO.Common;
using vigalileo.DTOs.System.Users;
using marketplace.Utilities.Const;
using marketplace.DTO.SystemManager.User;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace marketplace.Services.SystemManager.User
{
    public class UserService : BaseService<UserService>, IUserService
    {
        private readonly UserManager<TaiKhoan> _userManager;
        private readonly SignInManager<TaiKhoan> _signInManager;

        public UserService(UserManager<TaiKhoan> userManager,
            SignInManager<TaiKhoan> signInManager,
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            ILogger<UserService> logger) : base(configuration, unitOfWork, env, logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<ApiResult<bool>> RegisterAsync(RegisterDTO request)
        {
            var apiResult = new ApiResult<bool>(false);
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);
                if (user != null || await _userManager.FindByEmailAsync(request.Email) != null)
                {
                    apiResult.SetResult((int)ApiResultConst.CODE.USERNAME_EXISTS_E, false, false, null);
                    return apiResult;
                }

                user = request.GetUser();
                var createResult = await _userManager.CreateAsync(user, request.Password);
                if (createResult.Succeeded)
                {
                    apiResult.SetResult((int)ApiResultConst.CODE.SUCCESSFULLY_REGISTER_S, true, true, null);
                    return apiResult;
                }
                else
                {
                    apiResult.SetResult(ApiResultConst.CODE.REGISTER_FAILED_E, false, false, null);
                    return apiResult;
                }
            }
            catch (System.Exception ex)
            {
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }

        public async Task<ApiResult<string>> LoginAsync(LoginDTO request)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);
                if (user == null || (await _signInManager.PasswordSignInAsync(user, request.Password, true, true)).Succeeded == false)
                {
                    return new ApiResult<string>(ApiResultConst.CODE.USERNAME_PASSWORD_INCORRECT_E, false, null, null);
                }

                var claims = new[]
                {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim("DuXoNem", user.UserName)
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[ConfigKeyConst.TOKENS_KEY]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(_configuration[ConfigKeyConst.TOKENS_ISSUER],
                    _configuration[ConfigKeyConst.TOKENS_ISSUER],
                    claims,
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: creds);
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                return new ApiResult<string>(ApiResultConst.CODE.SUCCESS, true, jwtToken, null);
            }
            catch (System.Exception ex)
            {
                return DefaultApiResult.GetExceptionApiResult<string>(_env, ex, "");
            }
        }
    }


}

// if (user == null || (await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true)).Succeeded == false)\