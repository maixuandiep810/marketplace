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


        protected async Task<ApiResult<T>> GetAsync<T>(string url)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[ConfigKeyConst.BASE_API_ADDRESS]);
                var response = await client.GetAsync(url);
                var contentStream = await response.Content.ReadAsStreamAsync();
                if (response.IsSuccessStatusCode && response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var resultDeserializedObj = await JsonSerializer.DeserializeAsync<ApiResult<T>>(contentStream, new System.Text.Json.JsonSerializerOptions { IgnoreNullValues = false, PropertyNameCaseInsensitive = true });
                    return resultDeserializedObj;
                }
                return new ApiResult<T>();
            } 
            catch (System.Exception ex)
            {
                return new ApiResult<T>();
            }
        }

        protected async Task<TResponse> DeleteAsync<TResponse>(string url)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[ConfigKeyConst.BASE_API_ADDRESS]);
                var response = await client.DeleteAsync(url);
                var body = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    TResponse myDeserializedObjList = (TResponse)JsonSerializer.Deserialize(body, typeof(TResponse));
                    return myDeserializedObjList;
                }
                throw new Exception("BaseApiClient");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<ApiResult<bool>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }

}