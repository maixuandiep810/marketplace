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
using marketplace.Services.Utils;
using marketplace.DTO.Catalog.Branch;

namespace marketplace.Services.Catalog.Branch
{
    public class BranchService : BaseService<BranchService>, IBranchService
    {
        private readonly IImageService _imageService;

        public BranchService(IImageService imageService,
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            ILogger<BranchService> logger) : base(configuration, unitOfWork, env, logger)
        {
            _imageService = imageService;
        }

        /// <summary>
        /// 
        /// 
        ///     RRRRRRRRRRRRRRRRRRRRRRRRRRRR            R           RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR 
        ///  
        /// 
        /// 
        /// </summary>
        public async Task<ApiResult<BranchDTO>> GetBranchByCodeAsync(string branchCode)
        {
            try
            {
                LangNghe branch = await _unitOfWork.LangNgheRepository.GetByCodeAsync(branchCode);
                if (branch == null)
                {
                    return new ApiResult<BranchDTO>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, null, null);
                }
                var branchDTO = GetBranchDTOFromBranch(branch);
                return new ApiResult<BranchDTO>(ApiResultConst.CODE.SUCCESS, true, branchDTO, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<BranchService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<BranchDTO>(_env, ex, null);
            }
        }
        /// 
        public async Task<ApiResult<List<BranchDTO>>> GetAllCategoryAsync()
        {
            try
            {
                List<LangNghe> branchs = await _unitOfWork.LangNgheRepository.GetAllAsync();
                var branchDTOs = new List<BranchDTO>();
                foreach (var branch in branchs)
                {
                    var branchDTO = GetBranchDTOFromBranch(branch);
                    branchDTOs.Add(branchDTO);
                }
                return new ApiResult<List<BranchDTO>>(ApiResultConst.CODE.SUCCESS, true, branchDTOs, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<BranchService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<List<BranchDTO>>(_env, ex, null);
            }
        }
        /// 
        public async Task<ApiResult<List<string>>> GetAllBranchCodeAsync()
        {
            try
            {
                var codeValues = await _unitOfWork.LangNgheRepository.GetAllCodeValueAsync();
                return new ApiResult<List<string>>(ApiResultConst.CODE.SUCCESS, true, codeValues, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<BranchService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<List<string>>(_env, ex, null);
            }
        }
        /// 
        private BranchDTO GetBranchDTOFromBranch(LangNghe branch)
        {
            var branchDTO = ConverterDTOEntity.GetBranchDTOFromLangNghe(branch);
            return branchDTO;
        }
        /// <summary>
        /// 
        /// 
        /// 
        ///                     C   
        /// 
        /// 
        /// 
        /// </summary>
        public async Task<ApiResult<bool>> CreateAsync(CreateBranchDTO req)
        {
            try
            {
                var branch = await _unitOfWork.LangNgheRepository.GetByCodeAsync(req.Code);
                if (branch != null)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.ENTITY_CODE_EXISTS, false, false, null);
                }
                await CreateBranchFromCreateBranchDTO(req);
                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_CREATING_ENTITY_S, true, true, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<BranchService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }
        ///
        public async Task<ApiResult<bool>> CreateAsync(List<CreateBranchDTO> reqs)
        {
            var messages = new List<string>();
            var successMessages = "";
            var errorMessages = "";
            foreach (var req in reqs)
            {
                var result = false;
                try
                {
                    var branch = await _unitOfWork.LangNgheRepository.GetByCodeAsync(req.Code);
                    if (branch != null)
                    {
                        result = false;
                    }
                    await CreateBranchFromCreateBranchDTO(req);
                    result = true;
                }
                catch (System.Exception ex)
                {
                    LogUtils.LogException<BranchService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                    result = false;
                }
                if (result == true)
                {
                    var mess = "code: " + req.Code + ",";
                    successMessages += mess;
                }
                else
                {
                    var mess = "code: " + req.Code + ",";
                    errorMessages += mess;
                }
            }
            messages.Add("success: " + successMessages);
            messages.Add("error: " + errorMessages);
            return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_CREATING_ENTITY_S, true, true, null, messages);
        }
        private async Task CreateBranchFromCreateBranchDTO(CreateBranchDTO req)
        {
            var newBranch = ConverterDTOEntity.GetLangNgheFromCreateBranchDTO(req);
            await _unitOfWork.LangNgheRepository.AddAsync(newBranch);
            await _unitOfWork.SaveChangesAsync();
        }
        /// <summary>
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// </summary>
        public async Task<ApiResult<bool>> DeleteAsync(string branchCode)
        {
            try
            {
                var branch = await _unitOfWork.LangNgheRepository.GetByCodeAsync(branchCode);
                if (branch == null)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, false, null);
                }
                branch.DaXoa = true;
                await _unitOfWork.SaveChangesAsync();
                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_DELETING_ENTITY_S, true, true, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<BranchService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }
    }
}