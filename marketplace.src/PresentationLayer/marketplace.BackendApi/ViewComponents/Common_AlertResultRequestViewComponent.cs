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
    public class Common_AlertResultRequestViewComponent : ViewComponent
    {
        public Common_AlertResultRequestViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            var messagesViewData = ViewData[ViewDataConst.AlertMessages];
            var messages = new List<string>();
            var mess = "";
            if (messagesViewData == null)
            {
                return View("Null");
            }
            messages = (List<string>)messagesViewData;
            if (messages == null)
            {
                return View("Null");
            }
            foreach (var item in messages)
            {
                mess += item + ";";
            }
            ViewData[ViewDataConst.Mess] = mess;
            return View();
        }
    }
}