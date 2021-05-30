using System.Collections.Generic;
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
using marketplace.Utilities.Const;
using marketplace.DTO.SystemManager.User;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using marketplace.Services.Common;
using marketplace.Utilities.Common;

namespace marketplace.Services.SystemManager.User
{
    public class UserService : BaseService<UserService>, IUserService
    {
        private readonly UserManager<TaiKhoan> _userManager;
        private readonly SignInManager<TaiKhoan> _signInManager;
        private readonly IImageService _imageService;

        public UserService(UserManager<TaiKhoan> userManager,
            SignInManager<TaiKhoan> signInManager,
            IImageService imageService,
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            ILogger<UserService> logger) : base(configuration, unitOfWork, env, logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _imageService = imageService;
        }
        public async Task<ApiResult<bool>> RegisterAsync(RegisterDTO request)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);
                if (user != null || await _userManager.FindByEmailAsync(request.Email) != null)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.USERNAME_EXISTS_E, false, false, null);
                }

                user = RegisterDTO.ToTaiKhoan(request);
                var createResult = await _userManager.CreateAsync(user, request.Password);
                if (createResult.Succeeded)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_REGISTER_S, true, true, null);
                }
                else
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.REGISTER_FAILED_E, false, false, null);
                }
            }
            catch (System.Exception ex)
            {
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }

        /// <summary>
        /// 
        /// 
        ///             RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRREAD
        /// 
        /// 
        /// </summary>


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
                        new Claim(HttpContextConst.ID_JWT_KEY, user.Id.ToString())
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

        public async Task<ApiResult<UserDTO>> GetByUserNameAsync(string userName)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user == null)
                {
                    return new ApiResult<UserDTO>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, null, null);
                }
                var userDTO = new UserDTO(user);
                HinhAnh image = null;
                try
                {
                    image = await _unitOfWork.HinhAnhRepository.GetImageAsync(TypeOfEntityConst.USER, user.Id.ToString());
                }
                catch (System.Exception)
                {
                }
                var imageDTO = image != null ? new ImageDTO(image) : new ImageDTO();
                userDTO.ImageDTO = imageDTO;
                return new ApiResult<UserDTO>(ApiResultConst.CODE.SUCCESS, true, userDTO, null);
            }
            catch (Exception ex)
            {
                LogUtils.LogException<UserService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<UserDTO>(_env, ex, null);
            }
        }

        public async Task<List<string>> GetRoleNameAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return null;
                }

                var result = new List<string>();
                var roleNames = await _userManager.GetRolesAsync(user);
                if (roleNames != null)
                {
                    result.AddRange(roleNames);
                }
                return result;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }


}

// if (user == null || (await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true)).Succeeded == false)\