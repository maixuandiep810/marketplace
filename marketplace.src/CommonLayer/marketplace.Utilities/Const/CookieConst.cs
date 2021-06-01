using System;

namespace marketplace.Utilities.Const
{
    public static class CookieConst
    {
        public const string JwtToken = "JwtToken";
        public const string UserName = "UserName";
        public const string UserId = "UserId";
        public static Microsoft.AspNetCore.Http.CookieOptions CookieOptions = new Microsoft.AspNetCore.Http.CookieOptions()
            {
                Path = "/",
                MaxAge = TimeSpan.FromDays(30)
            };
    }
}