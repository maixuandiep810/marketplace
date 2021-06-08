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
using marketplace.DTO.Catalog.Store;

namespace marketplace.Services.Catalog.Store
{
    public class StoreService : BaseService<StoreService>, IStoreService
    {
        private readonly IImageService _imageService;

        public StoreService(IImageService imageService,
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            ILogger<StoreService> logger) : base(configuration, unitOfWork, env, logger)
        {
            _imageService = imageService;
        }

        public async Task<StoreDTO> GetBySellerIdAsync(string userId)
        {
            try
            {
                var store = await _unitOfWork.CuaHangRepository.GetBySellerIdAsync(userId);
                if (store == null)
                {
                    // return new ApiResult<UserDTO>(ApiResultConst.CODE.LOI_khong_tim_thay_tai_khoan, false, null, null);
                    throw new Exception();
                }
                var a = store.LangNghe;
                var storeDTO = await GetStoreDTO(store);

                return storeDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private async Task<StoreDTO> GetStoreDTO(CuaHang store)
        {
            var storeDTO = new StoreDTO(store);
            HinhAnh image = null;
            try
            {
                image = await _unitOfWork.HinhAnhRepository.GetImageAsync(TypeOfEntityConst.STORE, store.Id.ToString());
            }
            catch (System.Exception)
            {
            }
            var imageDTO = image != null ? new ImageDTO(image) : new ImageDTO();
            storeDTO.ImageDTO = imageDTO;
            return storeDTO;
        }
    }


}