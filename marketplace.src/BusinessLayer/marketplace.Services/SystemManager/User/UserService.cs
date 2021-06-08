using System.Net.Security;
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
using marketplace.DTO.Enum;

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








        // APIIIIIIIIIIIIIIIIIIIIIIIIIIIII
        public async Task<ApiResult<bool>> RegisterAsync(RegisterDTO request)
        {
            try
            {
                var existUser = await _userManager.FindByNameAsync(request.UserName);
                if (existUser != null || await _userManager.FindByEmailAsync(request.Email) != null)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.USERNAME_EXISTS_E, false, false, null);
                }

                var user = request.GetTaiKhoan();
                var createResult = await _userManager.CreateAsync(user, request.Password);
                if (createResult.Succeeded == false)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.LOI_dang_ky_tai_khoan_that_bai, false, false, null);
                }

                await SendConfirmEmail(user);

                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_REGISTER_S, true, true, null);
            }
            catch (System.Exception)
            {
                throw;
                // throw new Exception(ApiResultConst.MESSAGE(ApiResultConst.CODE.LOI_loi_he_thong));
            }
        }
        public async Task<bool> ConfirmUserEmail(string userEmail, string token)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userEmail);
                if (user == null)
                {
                    // return new ApiResult<bool>(ApiResultConst.CODE.CONFIRM_EMAIL_FAILED, false, false, null);
                    throw new Exception();
                }

                var resultConfirm = await _userManager.ConfirmEmailAsync(user, token);
                if (resultConfirm.Succeeded == false)
                {
                    // return new ApiResult<bool>(ApiResultConst.CODE.CONFIRM_EMAIL_FAILED, false, false, null);
                    throw new Exception();
                }

                _unitOfWork.TaiKhoanRepository.ActivateEntity(user);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {
                throw new Exception(ApiResultConst.MESSAGE(ApiResultConst.CODE.LOI_loi_he_thong));
            }
        }
        private async Task SendConfirmEmail(TaiKhoan user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodeToken = HttpUtility.UrlEncode(token);
            var email = user.Email;
            var host = _configuration[ConfigKeyConst.BASE_API_ADDRESS];
            var path = UrlConst.user_confirm_email_get;

            var confirmationLink = String.Format("{0}{1}?useremail={2}&token={3}", host, path, email, encodeToken);

            var messageContent = $"Please confirm your email, {confirmationLink}";

            await _emailSender.SendEmailAsync(email, EmailConst.CONFIRM_EMAIL_SUBJECT, messageContent);
        }
        public async Task<ApiResult<UserDTO>> LoginAsync(LoginDTO request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    return new ApiResult<UserDTO>(ApiResultConst.CODE.LOI_ten_tai_khoan_mat_khau_khong_dung, false, null, null);
                }
                if (await _userManager.IsEmailConfirmedAsync(user) == false)
                {
                    return new ApiResult<UserDTO>(ApiResultConst.CODE.LOI_chua_xac_nhan_email, false, null, null);
                }
                if ((await _signInManager.PasswordSignInAsync(user, request.Password, true, true)).Succeeded == false)
                {
                    return new ApiResult<UserDTO>(ApiResultConst.CODE.LOI_ten_tai_khoan_mat_khau_khong_dung, false, null, null);
                }
                if (user.TrangThai == TrangThai.KhongHoatDong)
                {
                    return new ApiResult<UserDTO>(ApiResultConst.CODE.LOI_tai_khoan_bi_tam_ngung, false, null, null);
                }

                var isInRole = await _userManager.IsInRoleAsync(user, request.RoleName);
                if (isInRole == false)
                {
                    return new ApiResult<UserDTO>(ApiResultConst.CODE.LOI_tai_khoan_khong_co_vai_tro, false, null, null);
                }

                var userDTO = await GetUserDTO(user);
                userDTO.RoleName = request.RoleName;

                var claims = new[]
                    {
                        new Claim(HttpContextConst.Id_Jwt_Key, user.Id.ToString())
                    };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[ConfigKeyConst.TOKENS_KEY]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(_configuration[ConfigKeyConst.TOKENS_ISSUER],
                    _configuration[ConfigKeyConst.TOKENS_ISSUER],
                    claims,
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: creds);
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                userDTO.JwtToken = jwtToken;

                return new ApiResult<UserDTO>(ApiResultConst.CODE.TC_dang_nhap, true, userDTO, null);
            }
            catch (System.Exception ex)
            {
                throw ex;
                // throw new Exception(ApiResultConst.MESSAGE(ApiResultConst.CODE.LOI_loi_he_thong));
            }
        }






        public async Task<bool> Authen(string userId, string roleName)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return false;
                }
                if (user.TrangThai == (TrangThai)Status.Inactive)
                {
                    return false;
                }

                var role = await _unitOfWork.VaiTroRepository.GetByNameAsync(roleName);
                if (role == null)
                {
                    return false;
                }
                if (role.TrangThai == (TrangThai)Status.Inactive)
                {
                    return false;
                }

                var isInRole = await _userManager.IsInRoleAsync(user, roleName);
                return isInRole;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }



        public async Task<UserDTO> GetByIdAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    // return new ApiResult<UserDTO>(ApiResultConst.CODE.LOI_khong_tim_thay_tai_khoan, false, null, null);
                    throw new Exception();
                }
                var userDTO = await GetUserDTO(user);
                var roles = await _userManager.GetRolesAsync(user);
                var roleNames = "";
                foreach (var item in roles)
                {
                    roleNames += item + ", ";
                }
                userDTO.RoleNames = roleNames;
                return userDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<ApiResult<bool>> UpdateMyAccountAsync(string userId, UpdateUserDTO request)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    throw new Exception();
                }
                user.NgaySinh = Convert.ToDateTime(request.Dob);
                user.HoTen = request.FullName;
                await _userManager.UpdateAsync(user);
                return new ApiResult<bool>(ApiResultConst.CODE.TC_cap_nhat, true, true, null);
            }
            catch (System.Exception)
            {
                throw;
            }
        }





















        public async Task<PageEntityDTO<UserDTO>> GetPageAsync(int? page = 0)
        {
            int start;
            if (page <= 0)
            {
                page = 1;
            }
            start = (int)(page - 1) * PageConst.Limit;
            try
            {
                var users = await _unitOfWork.TaiKhoanRepository.GetPageAsync(start, PageConst.Limit);
                if (users == null)
                {
                    throw new Exception();
                }
                var userDTOs = new List<UserDTO>();
                foreach (var user in users)
                {
                    try
                    {
                        var userDTO = await GetUserDTO(user);
                        userDTOs.Add(userDTO);
                    }
                    catch (System.Exception)
                    {
                    }
                }
                var totalRecord = await _unitOfWork.TaiKhoanRepository.CountRecordAsync();
                var pageUserDTO = new PageEntityDTO<UserDTO>();
                pageUserDTO.Page = page ?? 1;
                pageUserDTO.PageContent = userDTOs;
                pageUserDTO.TotalPage = totalRecord / PageConst.Limit + 1;
                return pageUserDTO;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private async Task<UserDTO> GetUserDTO(TaiKhoan user)
        {
            var userDTO = new UserDTO(user);
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
            return userDTO;
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











        // CHUA DUNG
        //
        //
        //
        //
        //
        public async Task<ApiResult<bool>> ResendConfirmEmail(string userEmail)// CHUA DU
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
    }


}





//
// public async Task<ApiResult<bool>> DeleteDataAllDetetedUserAsync()
// {
//     try
//     {
//         var deletedEntities = await _unitOfWork.TaiKhoanRepository.GetAllDeletedEntityAsync();
//         _unitOfWork.TaiKhoanRepository.DeleteDataAllDeletedEntity(deletedEntities);
//         await _unitOfWork.SaveChangesAsync();
//         return new ApiResult<bool>(ApiResultConst.CODE.SUCCESS, true, true, null);
//     }
//     catch (System.Exception ex)
//     {
//         LogUtils.LogException<UserService>(_env, ex, _logger, "Marketplace LogInfomation Message");
//         return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
//     }
// }
// if (user == null || (await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true)).Succeeded == false)\



// var jwtTokenEntity = ConverterDTOEntity.GetJwtTokenFromUser(user.Id, jwtToken);
// await _unitOfWork.JwtTokenRepository.AddAsync(jwtTokenEntity);



// public async Task<ApiResult<bool>> LogoutAsync(string userName, string token)
// {
//     try
//     {
//         var user = await _userManager.FindByNameAsync(userName);
//         if (user == null)
//         {
//             return new ApiResult<bool>(ApiResultConst.CODE.LOGOUT_FAILED, false, false, null);
//         }
//         return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_LOGOUT, false, false, null);
//     }
//     catch (Exception ex)
//     {
//         LogUtils.LogException<UserService>(_env, ex, _logger, "Marketplace LogInfomation Message");
//         return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
//     }
// }