using Microsoft.AspNetCore.Identity.UI.Services;
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
using marketplace.Services.Utils;
using marketplace.Data.Enums;
using System.Security.Policy;
using Microsoft.AspNetCore.WebUtilities;
using System.Web;

namespace marketplace.Services.SystemManager.User
{
    public class UserService : BaseService<UserService>, IUserService
    {
        private readonly UserManager<TaiKhoan> _userManager;
        private readonly SignInManager<TaiKhoan> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IImageService _imageService;

        public UserService(UserManager<TaiKhoan> userManager,
            SignInManager<TaiKhoan> signInManager,
            IEmailSender emailSender,
            IImageService imageService,
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            ILogger<UserService> logger) : base(configuration, unitOfWork, env, logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
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

                user = ConverterDTOEntity.GetTaiKhoanFromRegisterDTO(request);
                var createResult = await _userManager.CreateAsync(user, request.Password);
                if (createResult.Succeeded == false)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.REGISTER_FAILED_E, false, false, null);
                }

                await SendConfirmEmail(user);

                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_REGISTER_S, true, true, null);
            }
            catch (System.Exception ex)
            {
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }

        public async Task<ApiResult<bool>> ConfirmUserEmail(string userEmail, string token)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userEmail);
                if (user == null)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.CONFIRM_EMAIL_FAILED, false, false, null);
                }

                var resultConfirm = await _userManager.ConfirmEmailAsync(user, token);
                if (resultConfirm.Succeeded == false)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.CONFIRM_EMAIL_FAILED, false, false, null);
                }

                _unitOfWork.TaiKhoanRepository.ActivateEntity(user);
                await _unitOfWork.SaveChangesAsync();

                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_CONFIRM_EMAIL_ENTITY_S, true, true, null);
            }
            catch (System.Exception ex)
            {
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }

        public async Task<ApiResult<bool>> ResendConfirmEmail(string userEmail)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userEmail);
                if (user == null)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, false, null);
                }

                await SendConfirmEmail(user);

                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_RESEND_CONFIRM_EMAIL_ENTITY_S, true, true, null);
            }
            catch (System.Exception ex)
            {
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }

        private async Task SendConfirmEmail(TaiKhoan user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodeToken = HttpUtility.UrlEncode(token);
            var email = user.Email;
            var host = _configuration[ConfigKeyConst.BASE_API_ADDRESS];
            var path = UriConst.API_USERS_CONFIRM_EMAIL_GET_PATH_WITHOUT_PARAMS;

            var confirmationLink = String.Format("{0}{1}?useremail={2}&token={3}", host, path, email, encodeToken);

            var messageContent = $"Please confirm your email, {confirmationLink}";

            await _emailSender.SendEmailAsync(email, EmailConst.CONFIRM_EMAIL_SUBJECT, messageContent);
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
                if (user.TrangThai == TrangThai.KhongHoatDong)
                {
                    return new ApiResult<string>(ApiResultConst.CODE.ACCOUNT_NOT_ACTIVATED, false, null, null);
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
                var userDTO = ConverterDTOEntity.GetUserDTOFromTaiKhoan(user);
                HinhAnh image = null;
                try
                {
                    image = await _unitOfWork.HinhAnhRepository.GetImageAsync(TypeOfEntityConst.USER, user.Id.ToString());
                }
                catch (System.Exception)
                {
                }
                var imageDTO = image != null ? new ImageDTO(image) : null;
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
        /// <summary>
        /// 
        /// 
        /// 
        ///                     U
        /// 
        /// 
        /// 
        /// </summary>
        public async Task<ApiResult<bool>> ChangeStatusAsync(string userName, bool status)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user == null)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, false, null);
                }
                if (status == false)
                {
                    _unitOfWork.TaiKhoanRepository.DeactivateEntity(user);
                }
                else
                {
                    _unitOfWork.TaiKhoanRepository.ActivateEntity(user);
                }
                await _unitOfWork.SaveChangesAsync();
                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_DELETING_ENTITY_S, true, true, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<UserService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }
        /// <summary>
        /// 
        /// 
        /// 
        ///                                 D
        /// 
        /// 
        /// 
        /// </summary>
        public async Task<ApiResult<bool>> DeleteAsync(string userName)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user == null)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, false, null);
                }
                _unitOfWork.TaiKhoanRepository.DeleteEntity(user);
                await _unitOfWork.SaveChangesAsync();
                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_DELETING_ENTITY_S, true, true, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<UserService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }
        //
        public async Task<ApiResult<bool>> DeleteDataAllDetetedUserAsync()
        {
            try
            {
                var deletedEntities = await _unitOfWork.TaiKhoanRepository.GetAllDeletedEntityAsync();
                _unitOfWork.TaiKhoanRepository.DeleteDataAllDeletedEntity(deletedEntities);
                await _unitOfWork.SaveChangesAsync();
                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESS, true, true, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<UserService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }
    }


}

// if (user == null || (await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true)).Succeeded == false)\