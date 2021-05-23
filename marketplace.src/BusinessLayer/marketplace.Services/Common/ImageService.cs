using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.Data.Entities;
using marketplace.Data.UnitOfWorkPattern;
using marketplace.DTO.Common;
using marketplace.Utilities.Const;
using Microsoft.AspNetCore.Hosting;
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
        public async Task CreateAsync(HinhAnh image)
        {
            try
            {
                await _unitOfWork.HinhAnhRepository.AddAsync(image);
            }
            catch (System.Exception ex)
            {
                throw ex;
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
                    newImage.LaAnhMacDinh = false;
                    newImage.Loai = TypeOfEntityConst.USER_UPLOAD;
                    newImage.DoiTuongId = "";
                    await CreateAsync(newImage);
                    await _unitOfWork.CommitTransactionAsync();
                    imageRelUrls += newImage.Url + ", ";
                }
                catch (System.Exception ex)
                {
                }
            }
            imageRelUrls = imageRelUrls.Substring(imageRelUrls.Length - 1);
            return new ApiResult<string>(ApiResultConst.CODE.SUCCESS, true, imageRelUrls, "", "");
        }
    }
}