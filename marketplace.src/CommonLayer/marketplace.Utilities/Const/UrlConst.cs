namespace marketplace.Utilities.Const
{
    public static class UrlConst
    {
        public const string u_user_username_detail_get = @"/u/user/{userName}/detail";
        public const string u_user_username_update_post = @"/u/user/{userName}/update";
        public const string u_user_username_deactivate_get = @"/u/user/{userName}/deactivate";

        public const string ad_user_all_get = @"ad/user/all";
        public const string ad_user_username_detail_get = @"/ad/user/{userName}/detail";
        public const string ad_user_username_update_post = @"/ad/user/{userName}/update";
        public const string ad_user_username_deactivate_get = @"/ad/user/{userName}/deactivate";
        public const string ad_user_username_delete_get = @"/ad/user/{userName}/delete";

        public const string acc_user_logout_get = @"/acc/user/logout";

        public const string guest_home_get = @"/home";
        public const string g_user_login_post = @"/g/user/login";
        public const string g_user_confirm_email_get = @"/g/user/confirmemail";


































        // HOME
        public const string home_get = @"/";
        public const string tinh_get = @"/tinh/chi-tiet";
        // USER
        public const string user_login_get = @"/user/login";
        public const string user_login_post = @"/user/login";
        public const string user_register_get = @"/user/register";
        public const string user_register_post = @"/user/register";
        public const string user_confirm_email_get = @"/user/confirmemail";
        public const string user_myaccount_get = @"/user/myaccount";
        public const string user_update_post = @"/user/update";



        // ERROR
        public const string error_get = @"/error";


        // ADMIN
        public const string admin_user_getall_get = @"/admin/user/getall";
        public const string admin_user_getbyid_get = @"/admin/user/getbyid";
        public const string admin_store_getall_get = @"/admin/store/getall";
        public const string admin_store_getbyid_get = @"/admin/store/getbyid";
        public const string admin_product_getall_get = @"/admin/product/getall";
        public const string admin_product_getbyid_get = @"/admin/product/getbyid";



        // SELLER 
        public const string seller_mystore_detail = @"/seller/mystore/detail";






        public const string buyer_home_province_district_get = @"/{provinceCode}/{districtCode}";


        // public const string address_dropdown_area_get = @"/address/dropdown-area";
        // public const string common_error_get = @"/error";






















        public const string role_index_get = @"/role";
        public const string routepermission_index_get = @"/routepermission";













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

        public const string API_USERS_CHANGE_STATUS_DELETE_PATH = @"/users/{userName}/changestatus/{status}";

        public const string API_USERS_DELETE_DELETE_PATH = @"/users/{userName}";




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