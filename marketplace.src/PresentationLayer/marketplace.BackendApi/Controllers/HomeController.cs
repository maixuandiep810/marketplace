using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using marketplace.BackendApi.Models;
using marketplace.Utilities.Const;
using marketplace.DTO.Catalog.Product;
using marketplace.Services.Catalog.Address;
using marketplace.Services.Common;

namespace marketplace.BackendApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContentNavigationService _contentNavigationService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IContentNavigationService contentNavigationService)
        {
            _logger = logger;
            _contentNavigationService = contentNavigationService;
        }






        [HttpGet(UrlConst.home_get)]
        public IActionResult Index([FromQuery] SearchProductDTO searchProductDTO)
        {
            var jwtToken = HttpContext.Request.Cookies[CookieConst.JwtToken];
            ViewData[ViewDataConst.Role] = RoleConst.Guest;
            var messages = new List<string>();
            messages.Add("aaa");
            messages.Add("bbbbb");
            ViewData[ViewDataConst.AlertMessages] = null;
            if (String.IsNullOrEmpty(jwtToken) == true)
            {
                return View("~/Views/Home/Index-Guest-Buyer.cshtml");
            }
            // switch (switch_on)
            // {
                
            //     default:
            // }

            // View Error cua Admin, Seller, Co NAV,....
            return View();
        }


        [HttpGet(UrlConst.tinh_get)]
        public async Task<IActionResult> Province([FromQuery] string province, [FromQuery] SearchProductDTO searchProductDTO)
        {
            var jwtToken = HttpContext.Request.Cookies[CookieConst.JwtToken];
            ViewData[ViewDataConst.Role] = RoleConst.Guest;
            var contentNavigationDTO = await _contentNavigationService.GetNavigationAsync("province", province, "");
            ViewData[ViewDataConst.ContentNavigation] = contentNavigationDTO;
            var messages = new List<string>();
            ViewData[ViewDataConst.AlertMessages] = null;
            if (String.IsNullOrEmpty(jwtToken) == true)
            {
                return View("~/Views/Home/Province-Guest-Buyer.cshtml");
            }

            // View Error cua Admin, Seller, Co NAV,....
            return View();
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}
