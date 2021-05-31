namespace marketplace.Utilities.Const
{
    public static class UriConst
    {
        public const string API_USERS_ID_GET_PATH = @"/users/{userId}";
        public const string API_USERS_USER_NAME_GET_PATH = @"/users/{userName}";
        public const string API_USERS_REGISTER_POST_PATH = @"/users/register";
        public const string API_USERS_REGISTER_POST_REQUEST = @"/users/register";
        public const string API_USERS_CONFIRM_EMAIL_GET_PATH = @"/users/confirmemail";
        public const string API_USERS_CONFIRM_EMAIL_GET_PATH_WITHOUT_PARAMS = @"/users/confirmemail";
        public const string API_USERS_RESEND_CONFIRM_EMAIL_GET_PATH = @"/users/resendconfirmemail/{userEmail}";
        public const string API_USERS_RESEND_CONFIRM_EMAIL_GET_PATH_WITHOUT_PARAMS = @"/users/resendconfirmemail";
        public const string API_USERS_LOGIN_POST_PATH = @"/users/login";
        public const string API_USERS_LOGIN_POST_REQUEST = @"/users/login";
        public const string API_USERS_UPDATE_PUTCH_PATH = @"/users/login/{userId}";
        public const string API_USERS_UPDATE_PASSWORD_PUTCH_PATH = @"/users/login/{userId}/update-password";
        public const string API_PRODUCTS_CODE_GET_PATH = @"/products/{code}";
        public const string API_CATEGORIES_GET_PATH = @"/categories";
        public const string API_CATEGORIES_GET_PATH_RELATIVE = @"/categories";
        public const string API_CATEGORIES_CODES_GET_PATH = @"/categories/codes";
        public const string API_CATEGORIES_CODE_GET_PATH = @"/categories/{categoryCode}";
        public const string API_CATEGORIES_POST_PATH = @"/categories";
        public const string API_CATEGORIES_CODE_DELETE_PATH = @"/categories/{categoryCode}";
        public const string API_IMAGES_POST_PATH = @"/images";




        public const string GET = "GET";
        public const string POST = "POST";
        public const string PUTCH = "PUTCH";
        public const string DELETE = "DELETE";

    }
}