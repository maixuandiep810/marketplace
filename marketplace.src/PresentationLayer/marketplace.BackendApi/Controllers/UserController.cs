using System.Threading.Tasks;
using marketplace.DTOs.Common;
using marketplace.DTOs.System.Users;
using marketplace.Services.System.User;
using marketplace.Utilities.Const;
using marketplace.Utilities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

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
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = new ApiResult<bool>(false);
            // if (StringValues.IsNullOrEmpty(HttpContext.Request.Headers["Authorization"]) == false)
            // {
            //     throw new MPException(ApiResultConst.CODE.CLIENT_ERROR);
            // }
            if (!ModelState.IsValid)
            {
                throw new MPException(ApiResultConst.CODE.INVALID_REQUEST_DATA);
            }
            result = await _userService.RegisterAsync(request);
            return Ok(result);
        }
    }
}