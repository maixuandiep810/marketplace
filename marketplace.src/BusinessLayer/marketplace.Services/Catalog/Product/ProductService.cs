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

namespace marketplace.Services.Catalog.Product
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;
        private readonly IFileStorageService _fileStorageService;
        private readonly IWebHostEnvironment _env;

        public ProductService(IUnitOfWork unitOfWork, IImageService imageService, IFileStorageService fileStorageService, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
            _fileStorageService = fileStorageService;
            _env = env;
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
                var imageDTOs = images.ConvertAll(new Converter<HinhAnh, ImageDTO>(ImageDTO.FromHinhAnh));
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
                var newProduct = CreateProductDTO.ToSanPham(req);
                var newDetailProducts = req.DetailProductDTOs.ConvertAll(
                    new Converter<DetailProductDTO, ChiTietSanPham>(DetailProductDTO.ToChiTietSanPham)
                    );
                newProduct.ChiTietSanPhams = newDetailProducts;
                foreach (var createImageDTO in req.Images)
                {
                    try
                    {
                        var newImage = new HinhAnh();
                        newImage.Url = await _fileStorageService.SaveFileAsync(createImageDTO.FormImage, SystemConst.PRODUCT_IMAGE_FOLDER_NAME);
                        newImage.LaAnhMacDinh = createImageDTO.IsDefault;
                        newImage.Loai = TypeOfEntityConst.PRODUCT;
                        newImage.DoiTuongId = newProduct.Id.ToString();
                        await _imageService.CreateAsync(newImage);
                    }
                    catch (System.Exception)
                    {
                    }
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
                var product = await _unitOfWork.SanPhamRepository.GetByCodeAsync(productCode);
                if (product == null)
                {
                    return new ApiResult<bool>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, false, null);
                }
                product.DaXoa = true;
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