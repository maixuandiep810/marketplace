using System.Net.Http;
using System.Threading.Tasks;
using marketplace.DTOs.Common;
using marketplace.DTOs.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using marketplace.Utilities.DataUtils;
using System;
using marketplace.Utilities.Const;
using marketplace.Utilities.Exceptions;

namespace marketplace.ApiService
{
    public class UserApiClient : BaseApiClient
    {
        public UserApiClient(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration) :
            base(httpClientFactory, httpContextAccessor, configuration)
        {

        }

        public async Task<ApiResult<bool>> Login(LoginRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigKeyConst.BASE_API_ADDRESS]);
            var response = await client.PostAsync(UriConst.API_USERS_LOGIN_POST_REQUEST,
                            HttpUtils.GetApplicationJsonUTF8<LoginRequest>(request));
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                ApiResult<bool> myDeserializedObjList = (ApiResult<bool>)JsonSerializer.Deserialize(body, typeof(ApiResult<string>));

                return myDeserializedObjList;
            }

            throw new MPException(ApiResultConst.CODE.API_RESULT_INVALID_E);
        }


        public async Task<ApiResult<string>> Register(RegisterRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigKeyConst.BASE_API_ADDRESS]);
            var response = await client.PostAsync(UriConst.API_USERS_REGISTER_POST_REQUEST,
                            HttpUtils.GetApplicationJsonUTF8<RegisterRequest>(request));
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                ApiResult<string> myDeserializedObjList = (ApiResult<string>)JsonSerializer.Deserialize(body, typeof(ApiResult<string>));

                return myDeserializedObjList;
            }

            throw new MPException(ApiResultConst.CODE.API_RESULT_INVALID_E);
        }
    }
}