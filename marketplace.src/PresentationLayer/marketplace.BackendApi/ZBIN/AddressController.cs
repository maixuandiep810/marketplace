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
using marketplace.Services.Catalog.Address;

namespace marketplace.BackendApi.Controllers
{
    public class AddressController : Controller
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IAddressService _addressService; 

        public AddressController(ILogger<AddressController> logger, IAddressService addressService)
        {
            _logger = logger;
            _addressService = addressService;
        }










        public async Task<IActionResult> DropdownAreaPartilaView()
        {
            var result = await _addressService.GetAllAreaDTOAsync();
            if (result == null)
            {
                return PartialView("~/Views/Shared/MP/Common/_NullHtml.cshtml");
            }
            ViewData["AreaDTOs"] = result.Data;
            return PartialView("_DropdownArea");
        }
    }
}
