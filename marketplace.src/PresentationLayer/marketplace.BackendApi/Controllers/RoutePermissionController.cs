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
using marketplace.Services.SystemManager.RBAC;

namespace marketplace.BackendApi.Controllers
{
    public class RoutePermissionController : Controller
    {
        private readonly ILogger<RoutePermissionController> _logger;
        private readonly IRoutePermissionService _routePermissionService;

        public RoutePermissionController(ILogger<RoutePermissionController> logger, IRoutePermissionService routePermissionService)
        {
            _logger = logger;
            _routePermissionService = routePermissionService;
        }

        [HttpGet(UrlConst.routepermission_index_get)]
        public async Task<IActionResult> Index(int? page = 0)
        {
            var result = await _routePermissionService.GetPageByIdAsync(page);
            ViewData["ApiResult"] = result;

            return View();
        }
    }
}
