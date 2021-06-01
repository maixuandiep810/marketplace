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
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _roleService;

        public RoleController(ILogger<RoleController> logger, IRoleService roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }









        [HttpGet(UrlConst.role_index_get)]
        public async Task<IActionResult> Index(int? page = 0)
        {
            var result = await _roleService.GetPageAsync(page);
            ViewData["ApiResult"] = result;
            return View();
        }



    }
}
