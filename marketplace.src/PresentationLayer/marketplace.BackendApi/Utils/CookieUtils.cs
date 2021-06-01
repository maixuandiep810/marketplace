using marketplace.DTO.SystemManager.User;
using marketplace.Utilities.Const;
using Microsoft.AspNetCore.Http;

namespace marketplace.BackendApi.Utils
{
    public static class CookieUtils
    {
        public static void DeteteUserCookie(HttpContext httpContext)
        {
            httpContext.Response.Cookies.Delete(CookieConst.UserName);
            httpContext.Response.Cookies.Delete(CookieConst.JwtToken);
            httpContext.Response.Cookies.Delete(CookieConst.UserImage);
            httpContext.Response.Cookies.Delete(CookieConst.RoleGroup);
            httpContext.Response.Cookies.Delete(CookieConst.RememberMe);
            httpContext.Response.Cookies.Delete(CookieConst.UserId);
        }

        public static void SetUserCookie(HttpContext httpContext, UserDTO userDTO, string roleGroup, bool rememberMe)
        {
            httpContext.Response.Cookies.Append(CookieConst.UserName, userDTO.Username, CookieConst.CookieOptions);
            httpContext.Response.Cookies.Append(CookieConst.JwtToken, userDTO.JwtToken, CookieConst.CookieOptions);
            httpContext.Response.Cookies.Append(CookieConst.UserImage, userDTO.ImageDTO.Url, CookieConst.CookieOptions);
            httpContext.Response.Cookies.Append(CookieConst.RoleGroup, roleGroup, CookieConst.CookieOptions);
            httpContext.Response.Cookies.Append(CookieConst.RememberMe, rememberMe.ToString(), CookieConst.CookieOptions);
            httpContext.Response.Cookies.Append(CookieConst.UserId, userDTO.Id, CookieConst.CookieOptions);
        }
    }
}