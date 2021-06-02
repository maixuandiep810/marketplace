using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.Data.Entities;
using marketplace.Data.UnitOfWorkPattern;
using marketplace.DTO.Common;
using marketplace.Utilities.Const;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace marketplace.Services.Common
{
    public class ImageService : BaseService<ImageService>, IImageService
    {
        private readonly IFileStorageService _fileStorageService;
        public ImageService(IFileStorageService fileStorageService,
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            ILogger<ImageService> logger) : base(configuration, unitOfWork, env, logger)
        {
            _fileStorageService = fileStorageService;
        }
        public async Task CreateAsync(IFormFile formFile, 
                                        string imageUrl, 
                                        string relativeFolderPath,
                                        string entityId)
        {
            try
            {
                var newImage = new HinhAnh();
                if (formFile != null)
                {
                    newImage.Url = await _fileStorageService.SaveFileAsync(formFile, relativeFolderPath);
                }
                else if (String.IsNullOrEmpty(imageUrl) == false)
                {
                    newImage.Url = await _fileStorageService.DownloadFileAsync(imageUrl, relativeFolderPath);
                }
                else
                {
                    newImage.Url = "";
                }
                if (String.IsNullOrEmpty(newImage.Url) == false)
                {
                    newImage.Loai = TypeOfEntityConst.CATEGORY;
                    newImage.DoiTuongId = entityId;
                    await _unitOfWork.HinhAnhRepository.AddAsync(newImage);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
            catch (System.Exception)
            {
            }
        }
        public async Task<ApiResult<string>> UploadImagesAsync(CreateImagesDTO req)
        {
            var imageRelUrls = "";
            foreach (var formImage in req.FormImages)
            {
                try
                {
                    var newImage = new HinhAnh();
                    newImage.Url = await _fileStorageService.SaveFileAsync(formImage, SystemConst.UPLOAD_IMAGE_FOLDER_NAME);
                    if (String.IsNullOrEmpty(newImage.Url) == false)
                    {
                        newImage.Loai = TypeOfEntityConst.USER_UPLOAD;
                        newImage.DoiTuongId = "";
                        await _unitOfWork.HinhAnhRepository.AddAsync(newImage);
                        await _unitOfWork.SaveChangesAsync();
                        imageRelUrls += newImage.Url + ", ";
                    }
                }
                catch (System.Exception)
                {
                }
            }
            imageRelUrls = imageRelUrls.Substring(0, imageRelUrls.Length - 2);
            return new ApiResult<string>(ApiResultConst.CODE.SUCCESS, true, imageRelUrls, "", "");
        }
    }
}