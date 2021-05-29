using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using marketplace.BackendApi.Extensions;
using marketplace.DTO.Common;
using marketplace.Services.SystemManager.Auth;
using marketplace.Services.SystemManager.RBAC;
using marketplace.Services.SystemManager.User;
using marketplace.Utilities.Const;
using Microsoft.AspNetCore.Http;

namespace marketplace.BackendApi.Middlewares
{
    public class MPAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        public MPAuthenticationMiddleware(RequestDelegate next) => _next = next;
        public async Task Invoke(HttpContext httpContext, IJWTService jWTService, IUserService userService, IRoutePermissionService routePermissionService)
        {
            var path = httpContext.Request.Path;
            var action = httpContext.Request.Method;

            var currentRoutePermisisonDTO = await routePermissionService.GetRoutePermissionByPathActionAsync(path, action);
            if (currentRoutePermisisonDTO == null)
            {
                var apiResult = new ApiResult<bool>(ApiResultConst.CODE.ROUTE_NOT_FOUND, false, false, null);
                await httpContext.WriteJsonResponseAsync(200, apiResult);
                return;
            }
            if (currentRoutePermisisonDTO.IsAuthenticatedRoute == false)
            {
                httpContext.Items["IsAuthenticatedRoute"] = false;
                await _next(httpContext);
            }

            httpContext.Items["IsAuthenticatedRoute"] = true;

            var jwtToken = httpContext.Request.Headers["Authorization"].ToString();
            var roleList = new List<string>();

            if (String.IsNullOrEmpty(jwtToken) == true || String.IsNullOrWhiteSpace(jwtToken) == true)
            {
                roleList.Add("Guest");
                httpContext.Items["RoleNameList"] = roleList;
                httpContext.Items["UserId"] = "";
                await _next(httpContext);
            }
            else
            {
                roleList.Add("Guest");
                try
                {
                    var principal = jWTService.ValidateToken(jwtToken);
                    httpContext.User = principal;
                    var userId = "";
                    userId = principal.Claims.Where(x => x.Type == "Id").Select(x => x.Value).SingleOrDefault();
                    httpContext.Items["UserId"] = userId;
                    roleList.AddRange(await userService.GetRoleNameAsync(userId));
                    httpContext.Items["RoleNameList"] = roleList;
                }
                catch (System.Exception)
                {
                    httpContext.Items["RoleNameList"] = roleList;
                    httpContext.Items["UserId"] = "";
                }
                await _next(httpContext);
            }
        }
    }
}