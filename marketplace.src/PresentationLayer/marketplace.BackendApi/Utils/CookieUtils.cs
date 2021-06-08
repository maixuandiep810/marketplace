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

        public static string GetCookieValue(HttpContext httpContext, string cookieName)
        {
            return httpContext.Request.Cookies[cookieName];
        }

        public static void DeteteUserCookie(HttpContext httpContext)
        {
            httpContext.Response.Cookies.Delete(CookieConst.UserName);
            httpContext.Response.Cookies.Delete(CookieConst.Id);
            httpContext.Response.Cookies.Delete(CookieConst.JwtToken);
            httpContext.Response.Cookies.Delete(CookieConst.UserImage);
            httpContext.Response.Cookies.Delete(CookieConst.RoleName);
            httpContext.Response.Cookies.Delete(CookieConst.RememberMe);
        }

        public static void SetUserCookie(HttpContext httpContext, UserDTO userDTO, bool rememberMe)
        {
            httpContext.Response.Cookies.Append(CookieConst.UserName, userDTO.UserName, CookieConst.CookieOptions);
            httpContext.Response.Cookies.Append(CookieConst.Id, userDTO.Id, CookieConst.CookieOptions);
            httpContext.Response.Cookies.Append(CookieConst.JwtToken, userDTO.JwtToken, CookieConst.CookieOptions);
            if (userDTO.ImageDTO != null)
            {
                httpContext.Response.Cookies.Append(CookieConst.UserImage, userDTO.ImageDTO.Url, CookieConst.CookieOptions);
            }
            else
            {
                httpContext.Response.Cookies.Append(CookieConst.UserImage, "", CookieConst.CookieOptions);
            }
            httpContext.Response.Cookies.Append(CookieConst.RoleName, userDTO.RoleName, CookieConst.CookieOptions);
            httpContext.Response.Cookies.Append(CookieConst.RememberMe, rememberMe.ToString(), CookieConst.CookieOptions);
        }

        public static void GetUserHttpItems(HttpContext httpContext)
        {
            httpContext.Items[HttpContextConst.Id_Item_Key] = httpContext.Request.Cookies[CookieConst.Id];
            httpContext.Items[HttpContextConst.JwtToken_Item_Key] = httpContext.Request.Cookies[CookieConst.JwtToken];

            httpContext.Items[HttpContextConst.UserName_Item_Key] = httpContext.Request.Cookies[CookieConst.UserName];
            httpContext.Items[HttpContextConst.UserImage_Item_Key] = httpContext.Request.Cookies[CookieConst.UserImage];
            httpContext.Items[HttpContextConst.RoleName_Item_Key] = httpContext.Request.Cookies[CookieConst.RoleName];
            httpContext.Items[HttpContextConst.RemeberMe_Item_Key] = httpContext.Request.Cookies[CookieConst.RememberMe];
            httpContext.Items[HttpContextConst.SessionJwtToken] = httpContext.Request.Cookies[CookieConst.SessionJwtToken];
        }

        public static void SetUserGuestHttpItems(HttpContext httpContext)
        {
            httpContext.Items[HttpContextConst.Id_Item_Key] = "";
            httpContext.Items[HttpContextConst.JwtToken_Item_Key] = "";

            httpContext.Items[HttpContextConst.UserName_Item_Key] = "";
            httpContext.Items[HttpContextConst.UserImage_Item_Key] = "";
            httpContext.Items[HttpContextConst.RoleName_Item_Key] = RoleConst.Guest;
            httpContext.Items[HttpContextConst.RemeberMe_Item_Key] = "";
            httpContext.Items[HttpContextConst.SessionJwtToken] = "";
        }
    }
}