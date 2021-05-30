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
using Microsoft.IdentityModel.Tokens;

namespace marketplace.BackendApi.Middlewares
{
    public class MPAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        public MPAuthenticationMiddleware(RequestDelegate next) => _next = next;
        public async Task Invoke(HttpContext httpContext, IJWTService jWTService, IUserService userService, IRoutePermissionService routePermissionService)
        {
            var path = httpContext.Request.Path.ToString();
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
                httpContext.Items[HttpContextConst.IS_AUTHENTICATED_ROUTE_ITEM_KEY] = false;
                await _next(httpContext);
                return;
            }

            httpContext.Items[HttpContextConst.IS_AUTHENTICATED_ROUTE_ITEM_KEY] = true;

            var jwtToken = httpContext.Request.Headers[HttpContextConst.AUTHORIZATION_ITEM_KEY].ToString();
            var roleList = new List<string>();

            if (String.IsNullOrEmpty(jwtToken) == true || String.IsNullOrWhiteSpace(jwtToken) == true)
            {
                roleList.Add(RBACConst.GUEST_USER_NAME);
                httpContext.Items[HttpContextConst.ROLE_NAMES_ITEM_KEY] = roleList;
                httpContext.Items["UserId"] = "";
                await _next(httpContext);
                return;
            }
            else
            {
                roleList.Add(RBACConst.GUEST_USER_NAME);
                try
                {
                    var principal = jWTService.ValidateToken(jwtToken);
                    httpContext.User = principal;

                    var userId = "";
                    userId = principal.Claims.Where(x => x.Type == HttpContextConst.ID_JWT_KEY).Select(x => x.Value).SingleOrDefault();
                    httpContext.Items[RBACConst.GUEST_USER_NAME] = userId;
                    roleList.AddRange(await userService.GetRoleNameAsync(userId));

                    httpContext.Items[HttpContextConst.ROLE_NAMES_ITEM_KEY] = roleList;
                    httpContext.Items[HttpContextConst.USER_ID_ITEM_KEY] = userId;
                    await _next(httpContext);
                    return;
                }
                catch (SecurityTokenInvalidLifetimeException)
                {
                    var apiResult = new ApiResult<bool>(ApiResultConst.CODE.TOKEN_EXPIRED, false, false, null);
                    await httpContext.WriteJsonResponseAsync(200, apiResult);
                    return;
                }
                catch (System.Exception)
                {
                    httpContext.Items[HttpContextConst.ROLE_NAMES_ITEM_KEY] = roleList;
                    httpContext.Items[HttpContextConst.USER_ID_ITEM_KEY] = "";
                    await _next(httpContext);
                    return;
                }
            }
        }
    }
}