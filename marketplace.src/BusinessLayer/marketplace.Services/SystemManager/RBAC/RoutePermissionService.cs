using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using marketplace.Data.UnitOfWorkPattern;
using marketplace.DTO.Catalog.Product;
using marketplace.DTO.Common;
using Microsoft.Extensions.Configuration;
using marketplace.Utilities.Const;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using marketplace.Services.Common;
using System;
using marketplace.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using marketplace.DTO.Catalog.Category;
using Microsoft.Extensions.Logging;
using marketplace.Utilities.Common;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using marketplace.DTO.SystemManager.RBAC;
using System.Text.RegularExpressions;
using marketplace.Services.Utils;

namespace marketplace.Services.SystemManager.RBAC
{
    public class RoutePermissionService : BaseService<RoutePermissionService>, IRoutePermissionService
    {
        public RoutePermissionService(IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            ILogger<RoutePermissionService> logger) : base(configuration, unitOfWork, env, logger)
        {

        }











        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="action"></param>
        /// <returns></returns>

        public async Task<RoutePermissionDTO> GetRoutePermissionByPathActionAsync(string path, string action)
        {
            try
            {
                var routePermissions = await _unitOfWork.QuyenRouteRepository.GetAllAsync();
                if (routePermissions != null)
                {
                    var routePerm = routePermissions.Find(x =>
                        {
                            var isRightPath = Regex.IsMatch(path, x.PathRegex);
                            var isRightMethod = action == x.HanhDong;
                            var isRightRoute = isRightPath && isRightMethod;
                            return isRightRoute;
                        });
                    return new RoutePermissionDTO(routePerm);
                }
                return null;
            }
            catch (System.Exception)
            {
                return null;
            }
        }





        public async Task<ApiResult<PageEntityDTO<RoutePermissionDTO>>> GetPageByIdAsync(int? page = 0)
        {
            int start;
            if (page <= 0)
            {
                page = 1;
            }
            start = (int)(page - 1) * PageConst.Limit;
            try
            {
                var entities = await _unitOfWork.QuyenRouteRepository.GetPageByIdAsync(start, PageConst.Limit);
                if (entities == null)
                {
                    return new ApiResult<PageEntityDTO<RoutePermissionDTO>>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, null, null);
                }
                var entityDTOs = new List<RoutePermissionDTO>();
                foreach (var entity in entities)
                {
                    try
                    {
                        var entityDTO = ConverterDTOEntity.GetRoutePermissionDTOFromQuyenRoute(entity);
                        entityDTOs.Add(entityDTO);
                    }
                    catch (System.Exception)
                    {
                    }
                }
                // var totalRecord = await _unitOfWork.TaiKhoanRepository.CountRecordAsync();
                var pageEntityDTO = new PageEntityDTO<RoutePermissionDTO>();
                pageEntityDTO.Page = page ?? 1;
                pageEntityDTO.PageContent = entityDTOs;
                return new ApiResult<PageEntityDTO<RoutePermissionDTO>>(ApiResultConst.CODE.SUCCESS, true, pageEntityDTO, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<RoutePermissionService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<PageEntityDTO<RoutePermissionDTO>>(_env, ex, null);
            }
        }





































        /// <summary>
        /// 
        /// 
        /// 
        ///                     U
        /// 
        /// 
        /// 
        /// </summary>
        public async Task<ApiResult<bool>> ChangeStatusAsync(int routePrmissionId, bool status)
        {
            try
            {
                var routePermission = await _unitOfWork.QuyenRouteRepository.GetByIdAsync(routePrmissionId);
                if (routePermission == null)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, false, null);
                }
                if (status == false)
                {
                    _unitOfWork.QuyenRouteRepository.DeactivateEntity(routePermission);
                }
                else
                {
                    _unitOfWork.QuyenRouteRepository.ActivateEntity(routePermission);
                }
                await _unitOfWork.SaveChangesAsync();
                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_DELETING_ENTITY_S, true, true, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<RoutePermissionService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }
    }
}



// public async Task<bool> IsAuthenticatedRouteAsync(string path, string action)
// {
//     var routePermissionDTO = await GetRoutePermissionByPathActionAsync(path, action);
//     if (routePermissionDTO != null)
//     {
//         return routePermissionDTO.IsAuthenticatedRoute == true;
//     }
//     return false;
// }