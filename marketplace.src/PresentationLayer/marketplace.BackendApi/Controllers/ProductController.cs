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

namespace marketplace.BackendApi.Controllers
{

    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService productService)
        {
            _ProductService = productService;
        }

        [HttpPost(UriConst.API_PRODUCTS_CODE_GET_PATH)]
        public async Task<IActionResult> GetProductByCode(string code)
        {
            var result = new ApiResult<ProductDTO>(new ProductDTO());
            if (!ModelState.IsValid)
            {
                return Ok(new ApiResult<bool>(ApiResultConst.CODE.INVALID_REQUEST_DATA, false, false, null, ModelState.GetMessageList()));
            }
            result = await _ProductService.GetProductByCodeAsync(code);
            return Ok(result);
        }
    }
}