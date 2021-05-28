using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.Data.Entities;
using marketplace.DTO.Common;
using Microsoft.AspNetCore.Http;

namespace marketplace.Services.Common
{
    public interface IImageService
    {
        Task CreateAsync(IFormFile formFile,
                                        string imageUrl,
                                        string relativeFolderPath,
                                        string entityId);
        Task<ApiResult<string>> UploadImagesAsync(CreateImagesDTO req);
    }
}