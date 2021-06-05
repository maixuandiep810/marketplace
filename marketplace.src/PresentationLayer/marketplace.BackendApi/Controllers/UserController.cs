using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using marketplace.DTO.SystemManager.User;
using marketplace.Utilities.Const;
using marketplace.Services.SystemManager.User;
using Microsoft.AspNetCore.Http;
using marketplace.BackendApi.Utils;
using marketplace.DTO.Common;
using marketplace.BackendApi.Extensions;

namespace marketplace.BackendApi.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }






        //------------------------------------------------------------------------------------------


        [HttpGet(UrlConst.user_register_get)]
        public IActionResult Register()
        {
            return View();
        }
        // JSON
        [HttpPost(UrlConst.user_register_post)]
        public async Task<IActionResult> Register([FromBody] RegisterDTO request)
        {
            if (ModelState.IsValid == false)
            {
                return Ok(new ApiResult<bool>(ApiResultConst.CODE.INVALID_REQUEST_DATA, false, false, null, ModelState.GetMessageList()));
            }
            var result = await _userService.RegisterAsync(request);
            return Ok(result);
        }
        //
        [HttpPost(UrlConst.user_confirm_email_get)]
        public async Task<IActionResult> Register([FromQuery] string useremail, [FromQuery] string token)
        {
            if (ModelState.IsValid == false)
            {
                throw new Exception();
            }
            var result = await _userService.ConfirmUserEmail(useremail, token);
            if (result.IsSuccessed == false)
            {
                throw new Exception();
            }
            return Redirect("/");
        }




































        [HttpGet(UrlConst.ad_user_all_get)]
        public async Task<IActionResult> Ad_GetAll(int? page = 0)
        {
            var result = await _userService.GetPageAsync(page);
            ViewData["ApiResult"] = result;

            return View();
        }


        [HttpGet(UrlConst.user_login_get)]
        public IActionResult Login()
        {
            throw new Exception();
            return View();
        }

        // JSON
        [HttpPost(UrlConst.user_login_post)]
        public async Task<IActionResult> Login([FromForm] LoginDTO request)
        {
            /// <summary>
            /// VALIDATE
            /// </summary>
            var result = await _userService.LoginAsync(request);
            if (result.IsSuccessed == true)
            {
                // CookieUtils.SetUserCookie(HttpContext, result.Data, request.RoleGroup, request.RememberMe);

                if (request.RememberMe == false)
                {
                    HttpContext.Session.SetString(CookieConst.SessionJwtToken, true.ToString());
                }

                return RedirectToAction("Index", "Home");
            }

            ViewData["ApiResult"] = result;
            return View();
        }





        [HttpGet(UrlConst.acc_user_logout_get)]
        public IActionResult Logout()
        {
            // HttpContext.Session.Remove(CookieConst.SessionMP);
            HttpContext.Session.Clear();
            CookieUtils.DeteteUserCookie(HttpContext);
            return RedirectToAction("Index", "Home");
        }














        [HttpGet(UrlConst.ad_user_username_detail_get)]
        public async Task<IActionResult> Ad_DetailUser(string username)
        {
            /// <summary>
            /// VALIDATE
            /// </summary>
            var result = await _userService.GetByUserNameAsync(username);
            return View(result.Data);
        }


        [HttpGet(UrlConst.ad_user_username_detail_get)]
        public async Task<IActionResult> U_DetailUser(string username)
        {
            /// <summary>
            /// VALIDATE
            /// </summary>
            var result = await _userService.GetByUserNameAsync(username);
            return View(result.Data);
        }



        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}
