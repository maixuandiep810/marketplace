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
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }






        [HttpGet(UrlConst.error_get)]
        public IActionResult Index()
        {
            // var a = HttpContext.Items["ABC"].ToString();
            return View();
        }

    }
}
