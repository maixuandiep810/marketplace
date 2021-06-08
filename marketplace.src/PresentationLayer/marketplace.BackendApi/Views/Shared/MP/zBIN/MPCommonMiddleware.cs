

// using System.Net;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using marketplace.BackendApi.Extensions;
// using marketplace.DTO.Common;
// using marketplace.Services.SystemManager.Auth;
// using marketplace.Services.SystemManager.RBAC;
// using marketplace.Services.SystemManager.User;
// using marketplace.Utilities.Const;
// using Microsoft.AspNetCore.Http;
// using Microsoft.IdentityModel.Tokens;
// using marketplace.BackendApi.Utils;
// using Microsoft.AspNetCore.Http.Extensions;

// namespace marketplace.BackendApi.Middlewares
// {
//     public class MPCommonMiddleware
//     {
//         private readonly RequestDelegate _next;
//         public MPCommonMiddleware(RequestDelegate next) => _next = next;
//         public async Task Invoke(HttpContext httpContext)
//         {
//             CookieUtils.SetReturnUrl(httpContext);
//             await _next(httpContext);
//         }
//     }
// }








//         public static void SetReturnUrl(HttpContext httpContext)
//         {
//             var IsNewSession = String.IsNullOrEmpty(httpContext.Session.GetString(CookieConst.IsNewSession));
//             var returnUrl = "";
//             var currentUrl = httpContext.Request.GetEncodedUrl();
//             if (IsNewSession == false)
//             {
//                 returnUrl = httpContext.Request.Cookies[CookieConst.CurrentUrl];
//                 httpContext.Response.Cookies.Append(CookieConst.ReturnUrl, returnUrl);
//                 httpContext.Response.Cookies.Append(CookieConst.CurrentUrl, currentUrl);
//             }
//             httpContext.Session.SetString(CookieConst.IsNewSession, false.ToString());
//             httpContext.Response.Cookies.Append(CookieConst.CurrentUrl, currentUrl);
//         }