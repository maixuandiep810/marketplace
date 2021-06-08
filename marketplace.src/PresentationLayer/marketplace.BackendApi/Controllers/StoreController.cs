using System.Data.SqlTypes;
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
using marketplace.Services.Catalog.Store;

namespace marketplace.BackendApi.Controllers
{
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;
        private readonly IStoreService _storeService;

        public StoreController(ILogger<StoreController> logger, IStoreService storeService)
        {
            _logger = logger;
            _storeService = storeService;
        }






 
         //
        [HttpGet(UrlConst.seller_mystore_detail)]
        public async Task<IActionResult> Detail()
        {
            var userId = HttpContext.Items[HttpContextConst.Id_Item_Key].ToString();
            var result = await _storeService.GetBySellerIdAsync(userId);
            ViewData[ViewDataConst.UserDTO] = result;
            return View();
        }

    }
}
