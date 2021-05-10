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
    public class ProductApiClient : BaseApiClient
    {
        public ProductApiClient(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }


        protected async Task<TResponse> CreateAsync<TResponse>(string url)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[ConfigKeyConst.BASE_API_ADDRESS]);
                var response = await client.GetAsync(url);
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
    }
}