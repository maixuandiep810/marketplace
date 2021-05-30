namespace marketplace.Utilities.Const
{
    public static class ApiResultConst
    {
        public enum CODE
        {
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
            SUCCESSFULLY_CREATING_ENTITY_S = 9051,
            SUCCESSFULLY_DELETING_ENTITY_S = 9101
        }

        public static string MESSAGE(CODE valueCode)
        {
            switch (valueCode)
            {
                // API-RESULT
                case CODE.API_RESULT:
                    return "Result.";
                case CODE.API_RESULT_INVALID_E:
                    return "Error.";

                // ERROR
                case CODE.ERROR:
                    return "Error.";
                case CODE.CLIENT_ERROR:
                    return "Error.";
                case CODE.SERVER_ERROR:
                    return "Error.";
                case CODE.SUCCESS:
                    return "Successed.";

                // CLIENT-ERROR
                //---
                case CODE.USERNAME_EXISTS_E:
                    return "The username or email already exists.";
                case CODE.USERNAME_PASSWORD_INCORRECT_E:
                    return "The username or password is incorrect.";
                case CODE.ROLE_EXISTS_E:
                    return "The role already exists.";
                case CODE.INVALID_REQUEST_DATA:
                    return "Could not parse request data. Invalid Request Data.";
                case CODE.REGISTER_FAILED_E:
                    return "Registration failed";
                case CODE.NOT_AUTHORIZED_PLEASE_LOGIN_E:
                    return "You are not authorized to access this route. Please login!";
                case CODE.NOT_AUTHORIZED_LOGGEDIN_E:
                    return "You are not authorized to access this route";
                case CODE.TOKEN_EXPIRED:
                    return "Token has expired. Please login again!";
                    case CODE.BE_LOGGED_DONT_LOGIN:
                    return "You are logged in. Please dont login again";
                // ---
                case CODE.ENTITY_CODE_EXISTS:
                    return "The entity code already exists.";
                case CODE.ENTITY_NOT_FOUND_E:
                    return "Requested entity is not found";
                // ---
                case CODE.ROUTE_NOT_FOUND:
                    return "Route is not found";

                // SERVER_ERROR
                // ---
                case CODE.INTERNAL_SERVER_ERROR_E:
                    return "Internal Server Error.";

                // SUCCESS
                // ---
                case CODE.SUCCESSFULLY_REGISTER_S:
                    return "Your account has been succesfully created.";
                case CODE.SUCCESSFULLY_CREATING_ROLE_S:
                    return "The role has been succesfully created.";
                case CODE.SUCCESSFULLY_CREATING_ENTITY_S:
                    return "Entity has been succesfully created.";
                case CODE.SUCCESSFULLY_DELETING_ENTITY_S:
                    return "Entity has been succesfully deleted.";

                default:
                    return "Error.";
            }
        }

    }
}