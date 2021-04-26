using marketplace.Data.UnitOfWorkPattern;
using marketplace.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using marketplace.DTOs.Common;
using vigalileo.DTOs.System.Users;
using marketplace.Utilities.Exceptions;
using marketplace.Utilities.Const;
using marketplace.DTOs.System.Users;
using System;

namespace marketplace.Services.System.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<TaiKhoan> _userManager;
        private readonly SignInManager<TaiKhoan> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<TaiKhoan> userManager,
            SignInManager<TaiKhoan> signInManager,
            IUnitOfWork unitOfWork,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<ApiResult<bool>> RegisterAsync(RegisterRequest request)
        {
            var apiResult = new ApiResult<bool>(false);
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null || await _userManager.FindByEmailAsync(request.Email) != null)
            {
                throw new MPException(ApiResultConst.CODE.USERNAME_EXISTS_E);
            }

            user = UserDTO.GetTaiKhoan(request);
            var createResult = await _userManager.CreateAsync(user, request.Password);
            if (createResult.Succeeded)
            {
                apiResult.SetResult((int)ApiResultConst.CODE.SUCCESSFULLY_REGISTER_S, true, true,
                    ApiResultConst.MESSAGE(ApiResultConst.CODE.SUCCESSFULLY_REGISTER_S));
                return apiResult;
            }
            else
            {
                throw new MPException(ApiResultConst.CODE.REGISTER_FAILED_E);
            }
        }

        public async Task<ApiResult<string>> LoginAsync(LoginRequest request)
        {
            var apiResult = new ApiResult<string>("");
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null || (await _signInManager.PasswordSignInAsync(user, request.Password, true, true)).Succeeded == false)
            {
                throw new MPException(ApiResultConst.CODE.USERNAME_PASSWORD_INCORRECT_E);
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

            apiResult.SetResult(
                (int)ApiResultConst.CODE.SUCCESS, true, jwtToken,
                ApiResultConst.MESSAGE(ApiResultConst.CODE.SUCCESS));
            return apiResult;
        }
    }


}

// if (user == null || (await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true)).Succeeded == false)\