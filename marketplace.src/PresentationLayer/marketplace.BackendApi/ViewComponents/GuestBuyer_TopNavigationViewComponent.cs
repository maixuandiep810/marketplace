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
    public class GuestBuyer_TopNavigationViewComponent : ViewComponent
    {
        public GuestBuyer_TopNavigationViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}