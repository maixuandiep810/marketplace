namespace marketplace.Utilities.Const
{
    public static class ApiResultConst
    {
        public enum CODE
        {
            // user LOI
            LOI_tai_khoan_da_ton_tai = 10001,
            LOI_dang_ky_tai_khoan_that_bai = 10002,
            LOI_ten_tai_khoan_mat_khau_khong_dung = 10003,
            LOI_chua_xac_nhan_email = 10004,
            LOI_tai_khoan_bi_tam_ngung = 10005,
            LOI_tai_khoan_khong_co_vai_tro = 10006,
            LOI_khong_tim_thay_tai_khoan = 10007,
            // user TC
            TC_xac_nhan_email = 10101,
            TC_dang_nhap = 10102,
            TC_cap_nhat = 10103,


            // system LOI
            LOI_loi_he_thong = 11001,





            // API-RESULT
            API_RESULT = 1000,
            API_RESULT_INVALID_E = 1001,


            // ERROR
            ERROR = 5000,
            CLIENT_ERROR = 6000,
            SERVER_ERROR = 7000,
            SUCCESS = 9000,

            // CLIENT-ERROR
            // ---
            USERNAME_EXISTS_E = 6001,
            USERNAME_PASSWORD_INCORRECT_E = 6002,
            ROLE_EXISTS_E = 6003,
            INVALID_REQUEST_DATA = 6004,
            REGISTER_FAILED_E = 6005,
            NOT_AUTHORIZED_PLEASE_LOGIN_E = 6006,
            NOT_AUTHORIZED_LOGGEDIN_E = 6007,
            TOKEN_EXPIRED = 6008,
            BE_LOGGED_DONT_LOGIN = 6009,
            ACCOUNT_NOT_ACTIVATED = 6010,
            CONFIRM_EMAIL_FAILED = 6011,
            LOGOUT_FAILED = 6012,
            EMAIL_CONFIRM_FAIL = 6013,
            NOT_IN_ROLE_GROUP = 6014,
            // ---
            ENTITY_CODE_EXISTS = 6101,
            ENTITY_NOT_FOUND_E = 6102,
            // ---
            ROUTE_NOT_FOUND = 6201,

            // SERVER_ERROR
            // ---
            INTERNAL_SERVER_ERROR_E = 7001,


            // SUCCESS
            // ---
            SUCCESSFULLY_REGISTER_S = 9001,
            SUCCESSFULLY_CREATING_ROLE_S = 9002,
            SUCCESSFULLY_CREATING_ENTITY_S = 9003,
            SUCCESSFULLY_CONFIRM_EMAIL_ENTITY_S = 9004,
            SUCCESSFULLY_RESEND_CONFIRM_EMAIL_ENTITY_S = 9005,
            SUCCESSFULLY_LOGOUT = 9006,
            SUCCESSFULLY_DELETING_ENTITY_S = 9101
        }

        public static string MESSAGE(CODE valueCode)
        {
            switch (valueCode)
            {
                // user LOI
                case CODE.LOI_tai_khoan_da_ton_tai:
                    return "Tên tài khoản hoặc email đã tồn tại.";
                case CODE.LOI_dang_ky_tai_khoan_that_bai:
                    return "Đăng ký thất bại";
                case CODE.LOI_ten_tai_khoan_mat_khau_khong_dung:
                    return "Tên tài khoản hoặc mật khẩu không đúng.";
                case CODE.LOI_chua_xac_nhan_email:
                    return "Chưa xác nhận mail.";
                case CODE.LOI_tai_khoan_bi_tam_ngung:
                    return "Tài khoản bị tạm ngưng";
                case CODE.LOI_tai_khoan_khong_co_vai_tro:
                    return "Tài khoản không có vai trò này";
                case CODE.LOI_khong_tim_thay_tai_khoan:
                    return "Không tìm thấy tài khoản";
                // user TC
                case CODE.TC_dang_nhap:
                    return "Đăng nhập thành công";
                case CODE.TC_xac_nhan_email:
                    return "Xác thực email thành công";
                case CODE.TC_cap_nhat:
                    return "Cập nhật thành công";


                // system








                // API-RESULT
                case CODE.API_RESULT:
                    return "Result.";
                case CODE.API_RESULT_INVALID_E:
                    return "Error.";

                // ERROR
                case CODE.ERROR:
                    return "Lỗi.";
                case CODE.CLIENT_ERROR:
                    return "Lỗi.";
                case CODE.SERVER_ERROR:
                    return "Lỗi.";
                case CODE.SUCCESS:
                    return "Thành công.";

                // CLIENT-ERROR
                //---


                case CODE.ROLE_EXISTS_E:
                    return "Vai trò đã tồn tại.";
                case CODE.INVALID_REQUEST_DATA:
                    return "Dữ liệu nhập không đúng.";

                case CODE.NOT_AUTHORIZED_PLEASE_LOGIN_E:
                    return "Người dùng cần có tài khoản xác thực để thực hiện hành động này, vui lòng đăng nhập.";
                case CODE.NOT_AUTHORIZED_LOGGEDIN_E:
                    return "Người dùng không có đủ quyền thực hiện hành động này.";
                case CODE.TOKEN_EXPIRED:
                    return "Đăng nhập hết hạn, vui lòng đăng nhập lại.";
                case CODE.BE_LOGGED_DONT_LOGIN:
                    return "Người dùng đang đăng nhập, vui lòng không đăng nhập lại.";

                case CODE.CONFIRM_EMAIL_FAILED:
                    return "Xác thực email lỗi.";
                case CODE.LOGOUT_FAILED:
                    return "Đăng xuất lỗi.";

                case CODE.NOT_IN_ROLE_GROUP:
                    return "Tài khoản không thuộc vai trò yêu cầu.";
                // ---
                case CODE.ENTITY_CODE_EXISTS:
                    return "Thực thể đã tồn tại.";
                case CODE.ENTITY_NOT_FOUND_E:
                    return "Không tìm thấy thực thể";
                // ---
                case CODE.ROUTE_NOT_FOUND:
                    return "Không tìm thấy route này.";

                // SERVER_ERROR
                // ---
                case CODE.INTERNAL_SERVER_ERROR_E:
                    return "Internal Server Error.";

                // SUCCESS
                // ---
                case CODE.SUCCESSFULLY_REGISTER_S:
                    return "Đăng ký thành công";
                case CODE.SUCCESSFULLY_CREATING_ROLE_S:
                    return "Vai trò đã được tạo thành công.";
                case CODE.SUCCESSFULLY_CREATING_ENTITY_S:
                    return "Thực thể đã được tạo thành công.";
                case CODE.SUCCESSFULLY_DELETING_ENTITY_S:
                    return "Thực thể đã được xóa thành công.";

                case CODE.SUCCESSFULLY_RESEND_CONFIRM_EMAIL_ENTITY_S:
                    return "Thành công.";
                case CODE.SUCCESSFULLY_LOGOUT:
                    return "Thành công.";

                default:
                    return "Error.";
            }
        }

    }
}