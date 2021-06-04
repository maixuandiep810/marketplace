using System;
using System.Net;
using marketplace.DTO.SystemManager.User;
using marketplace.Utilities.Const;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace marketplace.BackendApi.Utils
{
    public static class CookieUtils
    {

        public static string GetCookieValue(HttpContext httpContext, string cookieName) {
            return httpContext.Request.Cookies[cookieName];
        }

        public static void DeteteUserCookie(HttpContext httpContext)
        {
            httpContext.Response.Cookies.Delete(CookieConst.UserName);
            httpContext.Response.Cookies.Delete(CookieConst.JwtToken);
            httpContext.Response.Cookies.Delete(CookieConst.UserImage);
            httpContext.Response.Cookies.Delete(CookieConst.Role);
            httpContext.Response.Cookies.Delete(CookieConst.RememberMe);
            httpContext.Response.Cookies.Delete(CookieConst.UserId);
        }

        public static void SetUserCookie(HttpContext httpContext, UserDTO userDTO, string role, bool rememberMe)
        {
            httpContext.Response.Cookies.Append(CookieConst.UserName, userDTO.Username, CookieConst.CookieOptions);
            httpContext.Response.Cookies.Append(CookieConst.JwtToken, userDTO.JwtToken, CookieConst.CookieOptions);
            httpContext.Response.Cookies.Append(CookieConst.UserImage, userDTO.ImageDTO.Url, CookieConst.CookieOptions);
            httpContext.Response.Cookies.Append(CookieConst.Role, role, CookieConst.CookieOptions);
            httpContext.Response.Cookies.Append(CookieConst.RememberMe, rememberMe.ToString(), CookieConst.CookieOptions);
            httpContext.Response.Cookies.Append(CookieConst.UserId, userDTO.Id, CookieConst.CookieOptions);
        }

        public static void SetReturnUrl(HttpContext httpContext)
        {
            var IsNewSession = String.IsNullOrEmpty(httpContext.Session.GetString(CookieConst.IsNewSession));
            var returnUrl = "";
            var currentUrl = httpContext.Request.GetEncodedUrl();
            if (IsNewSession == false)
            {
                returnUrl = httpContext.Request.Cookies[CookieConst.CurrentUrl];
                httpContext.Response.Cookies.Append(CookieConst.ReturnUrl, returnUrl);
                httpContext.Response.Cookies.Append(CookieConst.CurrentUrl, currentUrl);
            }
            httpContext.Session.SetString(CookieConst.IsNewSession, false.ToString());
            httpContext.Response.Cookies.Append(CookieConst.CurrentUrl, currentUrl);
        }
    }
}