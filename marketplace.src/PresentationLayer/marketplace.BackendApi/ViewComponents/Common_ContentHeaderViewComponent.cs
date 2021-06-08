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
    public class Common_ContentHeaderViewComponent : ViewComponent
    {
        public Common_ContentHeaderViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            var role = (string)ViewData[ViewDataConst.Role];
            var roleName = HttpContext.Items[HttpContextConst.RoleName_Item_Key].ToString();

            switch (roleName)
            {
                case RoleConst.Guest:
                case RoleConst.Buyer:
                    return View("Guest-Buyer");
                case RoleConst.Seller:
                    return View("Default");
                case RoleConst.Admin:
                    return View("Default");
                default:
                    break;
            }
            return View("Default");
        }
    }
}