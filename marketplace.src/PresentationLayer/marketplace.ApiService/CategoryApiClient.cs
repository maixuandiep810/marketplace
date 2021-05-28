using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using marketplace.Utilities.Const;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using marketplace.DTO.Common;
using marketplace.DTO.Catalog.Category;

namespace marketplace.ApiService
{
    public class CategoryApiClient : BaseApiClient, ICategoryApiClient
    {
        public CategoryApiClient(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<List<CategoryDTO>>> GetAllCategoryAsync()
        {
            return await GetAsync<List<CategoryDTO>>(UriConst.API_CATEGORIES_GET_PATH_RELATIVE);
        }

    }
}