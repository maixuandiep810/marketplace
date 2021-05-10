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

namespace marketplace.Services.Catalog.Category
{
    public class CategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;
        private readonly IFileStorageService _fileStorageService;
        private readonly IWebHostEnvironment _env;

        public CategoryService(IUnitOfWork unitOfWork, IImageService imageService, IFileStorageService fileStorageService, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
            _fileStorageService = fileStorageService;
            _env = env;
        }
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
                if (detailCategory == null)
                {
                    return new ApiResult<CategoryDTO>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, null, null);
                }
                var categoryDTO = new CategoryDTO(category, detailCategory);
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
                return new ApiResult<CategoryDTO>(ApiResultConst.CODE.SUCCESS, true, categoryDTO, null);
            }
            catch (System.Exception ex)
            {
                return DefaultApiResult.GetExceptionApiResult<CategoryDTO>(_env, ex, null);
            }
        }

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
                try
                {
                    var newImage = new HinhAnh();
                    newImage.Url = await _fileStorageService.SaveFileAsync(req.Image.FormImage, SystemConst.PRODUCT_IMAGE_FOLDER_NAME);
                    newImage.LaAnhMacDinh = true;
                    newImage.Loai = TypeOfEntityConst.CATEGORY;
                    newImage.DoiTuongId = newCategory.Id.ToString();
                    await _imageService.CreateAsync(newImage);
                }
                catch (System.Exception)
                {
                }
                await _unitOfWork.CommitTransactionAsync();
                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_CREATING_PRODUCT_S, false, false, null);
            }
            catch (System.Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }

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
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }
    }
}