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
using Microsoft.Extensions.Logging;
using marketplace.Services.Utils;

namespace marketplace.Services.Catalog.Product
{
    public class ProductService : BaseService<ProductService>
    {
        private readonly IImageService _imageService;
        private readonly IFileStorageService _fileStorageService;

        public ProductService(IImageService imageService,
            IFileStorageService fileStorageService,
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            ILogger<ProductService> logger) : base(configuration, unitOfWork, env, logger)
        {
            _imageService = imageService;
            _fileStorageService = fileStorageService;
        }
        public async Task<ApiResult<ProductDTO>> GetProductByCodeAsync(string productCode, string languageId)
        {
            try
            {
                SanPham product = await _unitOfWork.SanPhamRepository.GetByCodeAsync(productCode);
                if (product == null)
                {
                    return new ApiResult<ProductDTO>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, null, null);
                }
                ChiTietSanPham detailProduct = null;
                detailProduct = await _unitOfWork.ChiTietSanPhamRepository.GetByLanguageIdAsync(product.Id, languageId);
                if (detailProduct == null)
                {
                    return new ApiResult<ProductDTO>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, null, null);
                }
                var productDTO = new ProductDTO(product, detailProduct);
                List<HinhAnh> images = null;
                try
                {
                    images = await _unitOfWork.HinhAnhRepository.GetImagesAsync(productDTO.Id.ToString(), TypeOfEntityConst.PRODUCT);
                }
                catch (System.Exception)
                {
                }
                var imageDTOs = images != null ? ConverterDTOEntity.GetImageDTOsFromHinhAnhs(images) : null;
                productDTO.ImageDTOs = imageDTOs;
                return new ApiResult<ProductDTO>(ApiResultConst.CODE.SUCCESS, true, productDTO, null);
            }
            catch (System.Exception ex)
            {
                return DefaultApiResult.GetExceptionApiResult<ProductDTO>(_env, ex, null);
            }
        }

        public async Task<ApiResult<bool>> CreateAsync(CreateProductDTO req)
        {
            try
            {
                var product = await _unitOfWork.SanPhamRepository.GetByCodeAsync(req.Code);
                if (product != null)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.ENTITY_CODE_EXISTS, false, false, null);
                }
                await CreateSanPhamFromCreateProductDTO(req);
                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_CREATING_ENTITY_S, false, false, null);
            }
            catch (System.Exception ex)
            {
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }

        public async Task CreateSanPhamFromCreateProductDTO(CreateProductDTO req)
        {
            var newProduct = ConverterDTOEntity.GetSanPhamFromCreateProductDTO(req);
            var newDetailProducts = req.DetailProductDTOs.ConvertAll(
                new Converter<DetailProductDTO, ChiTietSanPham>(DetailProductDTO.ToChiTietSanPham)
                );
            newProduct.ChiTietSanPhams = newDetailProducts;
            await _unitOfWork.SanPhamRepository.AddAsync(newProduct);
            await _unitOfWork.SaveChangesAsync();
            foreach (var createImageDTO in req.Images)
            {
                await _imageService.CreateAsync(createImageDTO.FormImage, createImageDTO.ImageUrl, SystemConst.PRODUCT_IMAGE_FOLDER_NAME, newProduct.Id.ToString());
            }
        }
        /// <summary>
        /// 
        ///                 D
        /// 
        /// 
        /// </summary>
        public async Task<ApiResult<bool>> DeleteAsync(string productCode)
        {
            try
            {
                var product = await _unitOfWork.SanPhamRepository.GetByCodeAsync(productCode);
                if (product == null)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, false, null);
                }
                product.DaXoa = true;
                await _unitOfWork.SaveChangesAsync();
                return new ApiResult<bool>(ApiResultConst.CODE.SUCCESSFULLY_DELETING_ENTITY_S, true, true, null);
            }
            catch (System.Exception ex)
            {
                return DefaultApiResult.GetExceptionApiResult<bool>(_env, ex, false);
            }
        }
    }
}