using System;

namespace marketplace.Utilities.Const
{
    public static class CookieConst
    {
        public const string IsNewSession = "IsNewSession";
        public const string CurrentUrl = "CurrentUrl";
        public const string ReturnUrl = "ReturnUrl";
        public const string JwtToken = "JwtToken";
        public const string UserName = "UserName";
        public const string UserImage = "UserImage";
        public const string RememberMe = "RememberMe";
        public const string UserId = "UserId";
        public const string SessionMP = "SessionMP";
        public const string RoleGroup = "RoleGroup";

        public static Microsoft.AspNetCore.Http.CookieOptions CookieOptions = new Microsoft.AspNetCore.Http.CookieOptions()
        {
            Path = "/",
            MaxAge = TimeSpan.FromDays(30)
        };
    }
}