using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using marketplace.AdminApp.Models;
using marketplace.DTO.SystemManager.User;
using marketplace.ApiService;

namespace marketplace.AdminApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserApiClient _userApiClient;

        public UsersController(ILogger<UsersController> logger, IUserApiClient userApiClient)
        {
            _logger = logger;
            _userApiClient = userApiClient;
        }

        [HttpGet(UrlConst.USERS_LOGIN_GET)]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost(UrlConst.USERS_LOGIN_POST)]
        public async Task<IActionResult> Login([FromForm]LoginDTO request)
        {
            var result = await _userApiClient.LoginAsync(request);
            if (result.IsSuccessed == true)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["ApiResult"] = result;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
