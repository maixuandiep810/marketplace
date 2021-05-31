using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.DTO.Common;
using marketplace.DTO.SystemManager.User;
using marketplace.Services.SystemManager.User;
using marketplace.Utilities.Const;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using marketplace.BackendApi.Extensions;

namespace marketplace.BackendApi.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }



        /// <summary>
        /// 
        ///         CCC         CCC         CCC
        /// 
        /// 
        /// </summary>
        [HttpPost(UriConst.API_USERS_REGISTER_POST_PATH)]
        public async Task<IActionResult> Register([FromBody] RegisterDTO request)
        {
            // if (StringValues.IsNullOrEmpty(HttpContext.Request.Headers["Authorization"]) == false)
            // {
            //     throw new MPException(ApiResultConst.CODE.CLIENT_ERROR);
            // }
            if (!ModelState.IsValid)
            {
                return Ok(new ApiResult<bool>(ApiResultConst.CODE.INVALID_REQUEST_DATA, false, false, null, ModelState.GetMessageList()));
            }
            var result = await _userService.RegisterAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// 
        ///         RRR         RR          RR
        /// 
        /// 
        /// </summary>

        [HttpPost(UriConst.API_USERS_LOGIN_POST_PATH)]
        public async Task<IActionResult> Login([FromBody] LoginDTO req)
        {
            // var roleNames = (List<string>)HttpContext.Items[HttpContextConst.ROLE_NAMES_ITEM_KEY];
            // if (roleNames.Count > 1)
            // {
            //     return Ok(new ApiResult<bool>(ApiResultConst.CODE.BE_LOGGED_DONT_LOGIN, false, false, null, ModelState.GetMessageList()));
            // }
            if (!ModelState.IsValid)
            {
                return Ok(new ApiResult<bool>(ApiResultConst.CODE.INVALID_REQUEST_DATA, false, false, null, ModelState.GetMessageList()));
            }
            var result = await _userService.LoginAsync(req);
            return Ok(result);
        }
        ///
        [HttpGet(UriConst.API_USERS_USER_NAME_GET_PATH)]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiResult<bool>(ApiResultConst.CODE.INVALID_REQUEST_DATA, false, false, null, ModelState.GetMessageList()));
            }
            var result = await _userService.GetByUserNameAsync(userName);
            return Ok(result);
        }
        /// <summary>
        /// 
        ///         UUU     UUU     UUU
        /// 
        /// 
        /// </summary>
        [HttpGet(UriConst.API_USERS_CONFIRM_EMAIL_GET_PATH)]
        public async Task<IActionResult> ConfirmUserEmail([FromQuery] string userEmail, [FromQuery] string token)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiResult<bool>(ApiResultConst.CODE.INVALID_REQUEST_DATA, false, false, null, ModelState.GetMessageList()));
            }
            var result = await _userService.ConfirmUserEmail(userEmail, token);
            return Ok(result);
        }
        ///
        [HttpGet(UriConst.API_USERS_RESEND_CONFIRM_EMAIL_GET_PATH)]
        public async Task<IActionResult> ResendConfirmUserEmail(string userEmail)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiResult<bool>(ApiResultConst.CODE.INVALID_REQUEST_DATA, false, false, null, ModelState.GetMessageList()));
            }
            var result = await _userService.ResendConfirmEmail(userEmail);
            return Ok(result);
        }
        
        [HttpGet(UriConst.API_USERS_CHANGE_STATUS_DELETE_PATH)]
        public async Task<IActionResult> ChangeUserStatus(string userName, bool status)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiResult<bool>(ApiResultConst.CODE.INVALID_REQUEST_DATA, false, false, null, ModelState.GetMessageList()));
            }
            var result = await _userService.ChangeStatusAsync(userName, status);
            return Ok(result);
        }
        //
        [HttpDelete(UriConst.API_USERS_DELETE_DELETE_PATH)]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiResult<bool>(ApiResultConst.CODE.INVALID_REQUEST_DATA, false, false, null, ModelState.GetMessageList()));
            }
            var result = await _userService.DeleteAsync(userName);
            return Ok(result);
        }
    }
}