using System.Net;
using System.Threading.Tasks;
using marketplace.BackendApi.Extensions;
using marketplace.DTO.Common;
using marketplace.Services.Common;
using marketplace.Utilities.Const;
using Microsoft.AspNetCore.Mvc;

namespace marketplace.BackendApi.Controllers
{
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost(UriConst.API_IMAGES_POST_PATH)]
        public async Task<IActionResult> UploadImages([FromForm] CreateImagesDTO req)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiResult<bool>(ApiResultConst.CODE.INVALID_REQUEST_DATA, false, false, null, ModelState.GetMessageList()));
            }
            var result = await _imageService.UploadImagesAsync(req);
            return Ok(result);
        }
    }
}