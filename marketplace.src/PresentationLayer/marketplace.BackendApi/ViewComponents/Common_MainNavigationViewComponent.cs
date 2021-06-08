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
            var roleName = HttpContext.Items[HttpContextConst.RoleName_Item_Key].ToString();

            switch (roleName)
            {
                case RoleConst.Guest:
                    return View("Guest");               
                case RoleConst.Buyer:
                    return View("Buyer");  
                case RoleConst.Seller:
                    return View("Seller");  
                case RoleConst.Admin:
                    return View("Admin");      
                default:
                    break;
            }
            return View("Guest-Buyer");
        }
    }
}