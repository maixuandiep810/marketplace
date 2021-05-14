using System;
using System.Threading.Tasks;
using marketplace.DTO.SystemManager.User;
using marketplace.Services.SystemManager.User;
using marketplace.Utilities.Const;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using marketplace.BackendApi.Extensions;
using marketplace.Services.Catalog.Product;
using marketplace.DTO.Catalog.Product;
using marketplace.DTO.Common;
using marketplace.Services.Catalog.Category;
using marketplace.DTO.Catalog.Category;

namespace marketplace.BackendApi.Controllers
{
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }

        [HttpGet(UriConst.API_CATEGORIES_GET_PATH)]
        public async Task<IActionResult> GetAllCategory()
        {
            var acceptLangugage = HttpContext.Request.Headers["Accept-Language"].ToString() ?? LaunguageConst.DEFAULT;
            var result = await _CategoryService.GetAllCategoryAsync(acceptLangugage);
            return Ok(result);
        }

        [HttpGet(UriConst.API_CATEGORIES_CODES_GET_PATH)]
        public async Task<IActionResult> GetAllCategoryCode()
        {
            var result = await _CategoryService.GetAllCategoryCodeAsync();
            return Ok(result);
        }

        [HttpGet(UriConst.API_CATEGORIES_CODE_GET_PATH)]
        public async Task<IActionResult> GetCategoryByCodeAsync(string categoryCode)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiResult<bool>(ApiResultConst.CODE.INVALID_REQUEST_DATA, false, false, null, ModelState.GetMessageList()));
            }
            var acceptLangugage = HttpContext.Request.Headers["Accept-Language"].ToString() ?? LaunguageConst.DEFAULT;
            var result = await _CategoryService.GetCategoryByCodeAsync(categoryCode, acceptLangugage);
            return Ok(result);
        }

        [HttpPost(UriConst.API_CATEGORIES_POST_PATH)]
        public async Task<IActionResult> CreateCategoryAsync([FromForm] CreateCategoryDTO req)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiResult<bool>(ApiResultConst.CODE.INVALID_REQUEST_DATA, false, false, null, ModelState.GetMessageList()));
            }
            var result = await _CategoryService.CreateAsync(req);
            return Ok(result);
        }

        [HttpDelete(UriConst.API_CATEGORIES_CODE_DELETE_PATH)]
        public async Task<IActionResult> DeleteCategoryByCodeAsync(string categoryCode)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiResult<bool>(ApiResultConst.CODE.INVALID_REQUEST_DATA, false, false, null, ModelState.GetMessageList()));
            }
            var result = await _CategoryService.DeleteAsync(categoryCode);
            return Ok(result);
        }
    }
}