namespace marketplace.Utilities.Const
{
    public static class UriConst
    {
        public const string API_USERS_ID_GET_PATH = @"/users/{userId}";
        public const string API_USERS_NAME_GET_PATH = @"/users/{userName}";
        public const string API_USERS_REGISTER_POST_PATH = @"/users/register";
        public const string API_USERS_REGISTER_POST_REQUEST = @"/users/register";
        public const string API_USERS_LOGIN_POST_PATH = @"/users/login";
        public const string API_USERS_LOGIN_POST_REQUEST = @"/users/login";
        public const string API_USERS_UPDATE_PUTCH_PATH = @"/users/login/{userId}";
        public const string API_USERS_UPDATE_PASSWORD_PUTCH_PATH = @"/users/login/{userId}/update-password";



        public const string GET = "GET";
        public const string POST = "POST";
        public const string PUTCH = "PUTCH";
        public const string DELETE = "DELETE";

    }
}