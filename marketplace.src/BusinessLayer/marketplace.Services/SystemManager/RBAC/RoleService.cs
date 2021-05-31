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
using Microsoft.AspNetCore.Identity;

namespace marketplace.Services.SystemManager.RBAC
{
    public class RoleService : BaseService<RoleService>, IRoleService
    {
        private readonly RoleManager<VaiTro> _roleManager;
        private readonly IRoutePermissionService _routePermissionService;

        public RoleService(
            RoleManager<VaiTro> roleManager,
            IRoutePermissionService routePermissionService,
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            ILogger<RoleService> logger) : base(configuration, unitOfWork, env, logger)
        {
            _roleManager = roleManager;
            _routePermissionService = routePermissionService;
        }


        /// <summary>
        ///
        /// 
        ///                                       R
        /// 
        /// 
        /// </summary>

        public async Task<List<RoleDTO>> GetRoleDTOsByRoutePermissionAsync(RoutePermissionDTO routePermissionDTO)
        {
            var roleIds = await _unitOfWork.QuyenRouteVaiTroRepository.GetRouteIdByPermissionIdAsync(routePermissionDTO.Id);
            if (roleIds == null)
            {
                return null;
            }
            var roleDTOs = new List<RoleDTO>();
            foreach (var roleId in roleIds)
            {
                var role = await _roleManager.FindByIdAsync(roleId);
                if (role != null)
                {
                    roleDTOs.Add(new RoleDTO(role));
                }
            }
            return roleDTOs;
        }
        ///
        public async Task<List<string>> GetRoleNameByPathActionPermissionAsync(string path, string action)
        {
            var routePermissionDTO = await _routePermissionService.GetRoutePermissionByPathActionAsync(path, action);
            if (routePermissionDTO == null)
            {
                return null;
            }
            var roleDTOs = await GetRoleDTOsByRoutePermissionAsync(routePermissionDTO);
            var roleDTONames = roleDTOs.Select(x => x.Name).ToList();
            return roleDTONames;
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
        public async Task<ApiResult<bool>> ChangeStatusAsync(string roleName, bool status)
        {
            try
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, false, null);
                }
                if (status == false)
                {
                    _unitOfWork.VaiTroRepository.DeactivateEntity(role);
                }
                else
                {
                    _unitOfWork.VaiTroRepository.ActivateEntity(role);
                }
                await _unitOfWork.SaveChangesAsync();
                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_DELETING_ENTITY_S, true, true, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<RoleService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }
    }
}