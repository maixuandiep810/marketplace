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

        [HttpGet(UrlConst.user_index_get)]
        public async Task<IActionResult> Index(int? page = 0)
        {
            var result = await _userService.GetPageAsync(page);
            ViewData["ApiResult"] = result;

            return View();
        }


        [HttpGet(UrlConst.user_login_get)]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost(UrlConst.user_login_post)]
        public async Task<IActionResult> Login([FromForm] LoginDTO request)
        {
            /// <summary>
            /// VALIDATE
            /// </summary>
            var result = await _userService.LoginAsync(request);
            if (result.IsSuccessed == true)
            {
                CookieUtils.SetUserCookie(HttpContext, result.Data, request.RoleGroup, request.RememberMe);

                if (request.RememberMe == false)
                {
                    HttpContext.Session.SetString(CookieConst.SessionMP, CookieConst.SessionMP);
                }

                return RedirectToAction("Index", "Home");
            }

            ViewData["ApiResult"] = result;
            return View();
        }

        [HttpGet(UrlConst.user_logout_get)]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(CookieConst.SessionMP);
            HttpContext.Session.Clear();
            CookieUtils.DeteteUserCookie(HttpContext);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet(UrlConst.user_username_get)]
        public async Task<IActionResult> GetUser(string username)
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
