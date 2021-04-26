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
using marketplace.Utilities.Exceptions;
using marketplace.DTOs.Common;

namespace marketplace.ApiService
{
    public class BaseApiClient
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly IConfiguration _configuration;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        public BaseApiClient(IHttpClientFactory httpClientFactory,
           IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }


        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigKeyConst.BASE_API_ADDRESS]);
            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse) JsonSerializer.Deserialize(body, typeof(TResponse));

                return myDeserializedObjList;
            }
            throw new MPException(ApiResultConst.CODE.API_RESULT_INVALID_E);
        }

        public async Task<ApiResult<bool>> DeleteAsync(string id) {
            throw new NotImplementedException();
        }
    }

}