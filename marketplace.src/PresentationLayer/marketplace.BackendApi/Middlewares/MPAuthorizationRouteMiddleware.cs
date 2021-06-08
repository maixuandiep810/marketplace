// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using marketplace.BackendApi.Extensions;
// using marketplace.DTO.Common;
// using marketplace.Services.SystemManager.Auth;
// using marketplace.Services.SystemManager.RBAC;
// using marketplace.Services.SystemManager.User;
// using marketplace.Utilities.Const;
// using Microsoft.AspNetCore.Http;

// namespace marketplace.BackendApi.Middlewares
// {
//     public class MPAuthorizationRouteMiddleware
//     {
//         private readonly RequestDelegate _next;
//         public MPAuthorizationRouteMiddleware(RequestDelegate next) => _next = next;
//         public async Task Invoke(HttpContext httpContext, IUserService userService, IRoleService roleService)
//         {
//             var isAuthenticatedRoute = (bool)httpContext.Items[HttpContextConst.IS_AUTHENTICATED_ROUTE_ITEM_KEY];

//             if (isAuthenticatedRoute == false)
//             {
//                 await _next(httpContext);
//                 return;
//             }

//             var path = httpContext.Request.Path;
//             var action = httpContext.Request.Method;
//             var roleNames = (List<string>)httpContext.Items[HttpContextConst.ROLE_NAMES_ITEM_KEY];

//             var currentRoleDTONames = await roleService.GetRoleNameByPathActionPermissionAsync(path, action);

//             if (currentRoleDTONames.Contains<string>(RBACConst.GUEST_USER_NAME))
//             {
//                 await _next(httpContext);
//                 return;
//             }

//             if (roleNames.Count == 1)
//             {
//                 var apiResult = new ApiResult<bool>(ApiResultConst.CODE.NOT_AUTHORIZED_PLEASE_LOGIN_E, false, false, null);
//                 await httpContext.WriteJsonResponseAsync(200, apiResult);
//                 return;
//             }

//             if (currentRoleDTONames.Intersect(roleNames).Count() == 0)
//             {
//                 var apiResult = new ApiResult<bool>(ApiResultConst.CODE.NOT_AUTHORIZED_LOGGEDIN_E, false, false, null);
//                 await httpContext.WriteJsonResponseAsync(200, apiResult);
//                 return;
//             }

//             await _next(httpContext);
//             return;
//         }
//     }
// }    