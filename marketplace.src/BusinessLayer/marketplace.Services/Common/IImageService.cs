using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.Data.Entities;
using marketplace.DTO.Common;

namespace marketplace.Services.Common
{
    public interface IImageService
    {
        Task CreateAsync(HinhAnh image);
        Task<ApiResult<string>> UploadImagesAsync(CreateImagesDTO req);
    }
}