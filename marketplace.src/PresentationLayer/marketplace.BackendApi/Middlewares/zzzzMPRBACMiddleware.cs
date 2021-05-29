// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using marketplace.Services.SystemManager.Auth;
// using marketplace.Services.SystemManager.User;
// using Microsoft.AspNetCore.Http;

// namespace marketplace.BackendApi.Middlewares
// {
//     public class MPRBACMiddleware
//     {
//         private readonly RequestDelegate _next;
//         public MPRBACMiddleware(RequestDelegate next) => _next = next;
//         public async Task Invoke(HttpContext httpContext, IJWTService jWTService, IUserService userService, IRoleService roleService, IPermissionService permissionService)
//         {
//             var path = httpContext.Request.Path;
//             var action = httpContext.Request.Method;
       
//             if ((await permissionService.IsAuthenticatedRouteAsync(path, action) == false))
//             {
//                 await _next(httpContext);
//             }

//             var jwtToken = httpContext.Request.Headers["Authorization"].ToString();
//             var roleList = new List<string>();
//             var userId = "";
            
//             if (jwtToken == null)
//             {
//                 roleList.Add("Guest");
//                 httpContext.Items["RoleList"] = roleList;
//             }
//             else
//             {
//                 try
//                 {
//                     var principal = jWTService.ValidateToken(jwtToken);
//                     httpContext.User = principal;
//                     userId = principal.Claims.Where(x => x.Type == "Id").Select(x => x.Value).SingleOrDefault();
//                     httpContext.Items["UserId"] = userId;
//                     roleList = await userService.GetRoleNameAsync(userId);
//                     httpContext.Items["RoleList"] = roleList;
//                 }
//                 catch (System.Exception)
//                 {
//                     roleList.Add("Guest");
//                     httpContext.Items["RoleList"] = roleList;
//                 }
//             }
//         }
//     }
// }