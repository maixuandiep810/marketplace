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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost(UriConst.API_USERS_REGISTER_POST_PATH)]
        public async Task<IActionResult> Register([FromBody] RegisterDTO request)
        {
            var result = new ApiResult<bool>(false);
            // if (StringValues.IsNullOrEmpty(HttpContext.Request.Headers["Authorization"]) == false)
            // {
            //     throw new MPException(ApiResultConst.CODE.CLIENT_ERROR);
            // }
            if (!ModelState.IsValid)
            {
                return Ok(new ApiResult<bool>(ApiResultConst.CODE.INVALID_REQUEST_DATA, false, false, null, ModelState.GetMessageList()));
            }
            result = await _userService.RegisterAsync(request);
            return Ok(result);
        }
    }
}