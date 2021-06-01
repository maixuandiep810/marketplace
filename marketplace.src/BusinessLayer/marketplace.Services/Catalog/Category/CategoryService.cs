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

namespace marketplace.Services.Catalog.Category
{
    public class CategoryService : BaseService<CategoryService>, ICategoryService
    {
        private readonly IImageService _imageService;
        private readonly IFileStorageService _fileStorageService;

        public CategoryService(IImageService imageService,
            IFileStorageService fileStorageService,
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            ILogger<CategoryService> logger) : base(configuration, unitOfWork, env, logger)
        {
            _imageService = imageService;
            _fileStorageService = fileStorageService;
        }












        /// <summary>
        /// 
        /// 
        ///     RRRRRRRRRRRRRRRRRRRRRRRRRRRR            R           RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR 
        ///  
        /// 
        /// 
        /// </summary>
        public async Task<ApiResult<CategoryDTO>> GetCategoryByCodeAsync(string categoryCode, string languageId)
        {
            try
            {
                DanhMuc category = await _unitOfWork.DanhMucRepository.GetByCodeAsync(categoryCode);
                if (category == null)
                {
                    return new ApiResult<CategoryDTO>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, null, null);
                }
                var categoryDTO = await GetCategoryDTOFromCategoryAsync(category, languageId);
                return new ApiResult<CategoryDTO>(ApiResultConst.CODE.SUCCESS, true, categoryDTO, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<CategoryService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<CategoryDTO>(_env, ex, null);
            }
        } 
        /// 
        public async Task<ApiResult<List<CategoryDTO>>> GetAllCategoryAsync(string languageId)
        {
            try
            {
                List<DanhMuc> categories = await _unitOfWork.DanhMucRepository.GetAllAsync();
                var categoryDTOs = new List<CategoryDTO>();
                foreach (var category in categories)
                {
                    var categoryDTO = await GetCategoryDTOFromCategoryAsync(category, languageId);
                    categoryDTOs.Add(categoryDTO);
                }
                return new ApiResult<List<CategoryDTO>>(ApiResultConst.CODE.SUCCESS, true, categoryDTOs, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<CategoryService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<List<CategoryDTO>>(_env, ex, null);
            }
        } 
        /// 
        public async Task<ApiResult<List<string>>> GetAllCategoryCodeAsync()
        {
            try
            {
                var codeValues = await _unitOfWork.DanhMucRepository.GetAllCodeValueAsync();
                return new ApiResult<List<string>>(ApiResultConst.CODE.SUCCESS, true, codeValues, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<CategoryService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<List<string>>(_env, ex, null);
            }
        }
        /// 
        private async Task<CategoryDTO> GetCategoryDTOFromCategoryAsync(DanhMuc category, string languageId)
        {
            var categoryDTO = ConverterDTOEntity.GetCategoryDTOFromDanhMuc(category);
            HinhAnh image = null;
            try
            {
                image = await _unitOfWork.HinhAnhRepository.GetImageAsync(categoryDTO.Id.ToString(), TypeOfEntityConst.CATEGORY);
            }
            catch (System.Exception)
            {
            }
            var imageDTO = image != null ? ConverterDTOEntity.GetImageDTOFromHinhAnh(image) : null;
            categoryDTO.ImageDTO = imageDTO;
            return categoryDTO;
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
        public async Task<ApiResult<bool>> CreateAsync(CreateCategoryDTO req)
        {
            try
            {
                var category = await _unitOfWork.DanhMucRepository.GetByCodeAsync(req.Code);
                if (category != null)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.ENTITY_CODE_EXISTS, false, false, null);
                }
                await CreateCategoryFromCreateCategoryDTO(req);
                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_CREATING_ENTITY_S, true, true, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<CategoryService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }
        ///
        public async Task<ApiResult<bool>> CreateAsync(List<CreateCategoryDTO> reqs)
        {
            var messages = new List<string>();
            var successMessages = "";
            var errorMessages = "";
            foreach (var req in reqs)
            {
                var result = false;
                try
                {
                    var category = await _unitOfWork.DanhMucRepository.GetByCodeAsync(req.Code);
                    if (category != null)
                    {
                        result = false;
                    }
                    await CreateCategoryFromCreateCategoryDTO(req);
                    result = true;
                }
                catch (System.Exception ex)
                {
                    LogUtils.LogException<CategoryService>(_env, ex, _logger, "Marketplace LogInfomation Message");
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
        private async Task CreateCategoryFromCreateCategoryDTO(CreateCategoryDTO req)
        {
            var newCategory = ConverterDTOEntity.GetDanhMucFromCreateCategoryDTO(req);
            await _unitOfWork.DanhMucRepository.AddAsync(newCategory); // Vi Image khong chung Foreignkey la ID CATEGORY
            await _unitOfWork.SaveChangesAsync();
            await _imageService.CreateAsync(req.Image.FormImage, req.Image.ImageUrl, SystemConst.CATEGORY_IMAGE_FOLDER_NAME, newCategory.Id.ToString());
        }
        /// <summary>
        /// 
        /// 
        /// 
        ///                         D
        /// 
        /// 
        /// 
        /// </summary>
        public async Task<ApiResult<bool>> DeleteAsync(string categoryCode)
        {
            try
            {
                var category = await _unitOfWork.DanhMucRepository.GetByCodeAsync(categoryCode);
                if (category == null)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, false, null);
                }
                category.DaXoa = true;
                await _unitOfWork.SaveChangesAsync();
                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_DELETING_ENTITY_S, true, true, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<CategoryService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }
    }
}

// public async Task<ApiResult<List<CategoryDTO>>> GetAllCategoryAsync(string languageId)
// {
//     try
//     {
//         List<DanhMuc> categories = await _unitOfWork.DanhMucRepository.GetAllAsync();
//         var categoryDTOs = new List<CategoryDTO>();
//         foreach (var category in categories)
//         {
//             ChiTietDanhMuc detailCategory = null;
//             detailCategory = await _unitOfWork.ChiTietDanhMucRepository.GetByLanguageIdAsync(category.Id, languageId);
//             var categoryDTO = detailCategory != null ? new CategoryDTO(category, detailCategory) : new CategoryDTO(category);
//             HinhAnh image = null;
//             try
//             {
//                 image = await _unitOfWork.HinhAnhRepository.GetImageAsync(categoryDTO.Id.ToString(), TypeOfEntityConst.PRODUCT);
//             }
//             catch (System.Exception)
//             {
//             }
//             var imageDTO = image != null ? ConverterDTOEntity.GetImageDTOFromHinhAnh(image) : null;
//             categoryDTO.ImageDTO = imageDTO;
//             categoryDTOs.Add(categoryDTO);
//         }
//         return new ApiResult<List<CategoryDTO>>(ApiResultConst.CODE.SUCCESS, true, categoryDTOs, null);
//     }
//     catch (System.Exception ex)
//     {
//         LogUtils.LogException<CategoryService>(_env, ex, _logger, "Marketplace LogInfomation Message");
//         return DefaultApiResult.GetExceptionApiResult<List<CategoryDTO>>(_env, ex, null);
//     }
// }



// public async Task<ApiResult<bool>> CreateAsync(List<CreateCategoryDTO> reqs)
// {
//     var messages = new List<string>();
//     var successMessages = "";
//     var errorMessages = "";
//     foreach (var req in reqs)
//     {
//         var result = await CreateAsync(req);
//         if (result.IsSuccessed == true)
//         {
//             var mess = "code: " + req.Code + ",";
//             successMessages += mess;
//         }
//         else
//         {
//             var mess = "code: " + req.Code + ",";
//             errorMessages += mess;
//         }
//     }
//     messages.Add("success: " + successMessages);
//     messages.Add("error: " + errorMessages);
//     return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_CREATING_ENTITY_S, true, true, null, messages);
// }