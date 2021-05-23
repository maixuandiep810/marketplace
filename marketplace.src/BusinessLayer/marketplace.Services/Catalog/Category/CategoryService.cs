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
        /// 
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
                ChiTietDanhMuc detailCategory = null;
                detailCategory = await _unitOfWork.ChiTietDanhMucRepository.GetByLanguageIdAsync(category.Id, languageId);
                var categoryDTO = detailCategory != null ? new CategoryDTO(category, detailCategory) : new CategoryDTO(category);
                HinhAnh image = null;
                try
                {
                    image = await _unitOfWork.HinhAnhRepository.GetImageAsync(TypeOfEntityConst.CATEGORY, categoryDTO.Id.ToString());
                }
                catch (System.Exception)
                {
                }
                var imageDTO = ImageDTO.FromHinhAnh(image);
                categoryDTO.ImageDTO = imageDTO;
                return new ApiResult<CategoryDTO>(ApiResultConst.CODE.SUCCESS, true, categoryDTO, null);
            }
            catch (System.Exception ex)
            {
                LogUtils.LogException<CategoryService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<CategoryDTO>(_env, ex, null);
            }
        }
        ///
        /// 
        /// 
        public async Task<ApiResult<List<CategoryDTO>>> GetAllCategoryAsync(string languageId)
        {
            try
            {
                List<DanhMuc> categories = await _unitOfWork.DanhMucRepository.GetAllAsync();
                var categoryDTOs = new List<CategoryDTO>();
                foreach (var category in categories)
                {
                    ChiTietDanhMuc detailCategory = null;
                    detailCategory = await _unitOfWork.ChiTietDanhMucRepository.GetByLanguageIdAsync(category.Id, languageId);
                    var categoryDTO = detailCategory != null ? new CategoryDTO(category, detailCategory) : new CategoryDTO(category);
                    HinhAnh image = null;
                    try
                    {
                        image = await _unitOfWork.HinhAnhRepository.GetImageAsync(categoryDTO.Id.ToString(), TypeOfEntityConst.PRODUCT);
                    }
                    catch (System.Exception)
                    {
                    }
                    var imageDTO = ImageDTO.FromHinhAnh(image);
                    categoryDTO.ImageDTO = imageDTO;
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
        /// 
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

        /// <summary>
        /// 
        /// 
        /// 
        /// CREATE CATEGORY: 1 cate, N cate
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
                var newCategory = CreateCategoryDTO.ToDanhMuc(req);
                var newDetailCategory = req.DetailCategoryDTOs.ConvertAll(
                    new Converter<DetailCategoryDTO, ChiTietDanhMuc>(DetailCategoryDTO.ToChiTietDanhMuc)
                    );
                newCategory.ChiTietDanhMucs = newDetailCategory;
                await _unitOfWork.DanhMucRepository.AddAsync(newCategory); // Vi Image khong chung Foreignkey la ID CATEGORY
                await _unitOfWork.CommitTransactionAsync();
                try
                {
                    var newImage = new HinhAnh();
                    newImage.Url = await _fileStorageService.SaveFileAsync(req.Image.FormImage, SystemConst.CATEGORY_IMAGE_FOLDER_NAME);
                    newImage.LaAnhMacDinh = true;
                    newImage.Loai = TypeOfEntityConst.CATEGORY;
                    newImage.DoiTuongId = newCategory.Id.ToString();
                    await _imageService.CreateAsync(newImage);
                    await _unitOfWork.CommitTransactionAsync();
                }
                catch (System.Exception)
                {
                }
                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_CREATING_ENTITY_S, false, false, null);
            }
            catch (System.Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                LogUtils.LogException<CategoryService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }
        ///
        ///
        /// 
        public async Task<ApiResult<bool>> CreateAsync(List<CreateCategoryDTO> reqs)
        {
            var messages = new List<string>();
            var successMessages = "";
            var errorMessages = "";
            foreach (var req in reqs)
            {
                var result = await CreateAsync(req);
                if (result.IsSuccessed == true)
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
        /// <summary>
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// </summary>
        public async Task<ApiResult<bool>> DeleteAsync(string productCode)
        {
            try
            {
                var category = await _unitOfWork.DanhMucRepository.GetByCodeAsync(productCode);
                if (category == null)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, false, null);
                }
                category.DaXoa = true;
                await _unitOfWork.CommitTransactionAsync();
                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_DELETING_ENTITY_S, true, true, null);
            }
            catch (System.Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                LogUtils.LogException<CategoryService>(_env, ex, _logger, "Marketplace LogInfomation Message");
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }
    }
}