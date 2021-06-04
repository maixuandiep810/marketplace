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
using marketplace.BackendApi.Utils;

namespace marketplace.BackendApi.ViewComponents
{
    public class Common_MainNavigationViewComponent : ViewComponent
    {
        public Common_MainNavigationViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            var role = (string) ViewData[ViewDataConst.Role];
            if (role == RoleConst.Guest)
            {
                return View("Guest");
            }
            return View("Guest");
        }
    }
}