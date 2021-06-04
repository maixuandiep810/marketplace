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

namespace marketplace.BackendApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }






        [HttpGet(UrlConst.buyer_home_get)]
        [HttpGet(UrlConst.buyer_home_province_district_get)]
        public IActionResult Index(string provinceCode, string districtCode, [FromQuery] SearchProductDTO searchProductDTO)
        {
            var jwtToken = HttpContext.Request.Cookies[CookieConst.JwtToken];
            if (String.IsNullOrEmpty(jwtToken) == true)
            {
                return View("Index-Guest-Buyer");
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
