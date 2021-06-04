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

namespace marketplace.BackendApi.ViewComponents
{
    public class DropdownAreaViewComponent : ViewComponent
    {
        private readonly IAddressService _addressService;
        public DropdownAreaViewComponent(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _addressService.GetAllAreaDTOAsync();
            ViewData["AreaDTOs"] = result.Data;
            return View();
        }
    }
}