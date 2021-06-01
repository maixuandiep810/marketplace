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

        [HttpGet(UrlConst.user_login_get)]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost(UrlConst.user_login_post)]
        public async Task<IActionResult> Login([FromForm] LoginDTO request)
        {
            var result = await _userService.LoginAsync(request);
            if (result.IsSuccessed == true)
            {
                if (request.RememberMe == true)
                {
                    Response.Cookies.Append(CookieConst.JwtToken, result.Data.JwtToken, CookieConst.CookieOptions);
                }
                else
                {
                    HttpContext.Session.SetString(CookieConst.JwtToken, result.Data.JwtToken);
                }
                Response.Cookies.Append(CookieConst.UserName, result.Data.Username, CookieConst.CookieOptions);

                return RedirectToAction("Index", "Home");
            }

            ViewData["ApiResult"] = result;
            return View();
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}
