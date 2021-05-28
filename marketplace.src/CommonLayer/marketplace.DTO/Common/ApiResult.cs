using System;
using System.Collections.Generic;
using marketplace.Utilities.Const;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace marketplace.DTO.Common
{
    public class ApiResult<T>
    {
        public int Code { get; set; }
        public bool IsSuccessed { get; set; }
        public T Data { get; set; }
        public List<string> Messages { get; set; }
        public string StackTrace { get; set; }

        public ApiResult() : this(default(T))
        {
            
        }

        public ApiResult(T defaultData)
        {
            Code = (int)ApiResultConst.CODE.ERROR;
            IsSuccessed = false;
            Data = defaultData;
            Messages = new List<string>();
            Messages.Add(ApiResultConst.MESSAGE(ApiResultConst.CODE.ERROR));
        }

        public ApiResult(int code, bool isSuccessed, T data, string stackTrace)
        {
            SetResult(code, isSuccessed, data, stackTrace);
        }

        public ApiResult(ApiResultConst.CODE code, bool isSuccessed, T data, string stackTrace)
        {
            SetResult(code, isSuccessed, data, stackTrace);
        }

        public ApiResult(ApiResultConst.CODE code, bool isSuccessed, T data, string stackTrace, params string[] messages)
        {
            SetResult(code, isSuccessed, data, stackTrace, messages);
        }

        public ApiResult(int code, bool isSuccessed, T data, string stackTrace, params string[] messages)
        {
            SetResult(code, isSuccessed, data, stackTrace, messages);
        }

        public ApiResult(ApiResultConst.CODE code, bool isSuccessed, T data, string stackTrace, List<string> messages)
        {
            SetResult(code, isSuccessed, data, stackTrace, messages);
        }

        public ApiResult(int code, bool isSuccessed, T data, string stackTrace, List<string> messages)
        {
            SetResult(code, isSuccessed, data, stackTrace, messages);
        }


        public void SetResult(int code, bool isSuccessed, T data, string stackTrace)
        {
            SetResult((ApiResultConst.CODE)code, isSuccessed, data, stackTrace);
        }

        public void SetResult(ApiResultConst.CODE code, bool isSuccessed, T data, string stackTrace)
        {
            Code = (int)code;
            IsSuccessed = isSuccessed;
            Data = data;
            StackTrace = stackTrace;

            Messages = new List<string>();
            Messages.Add(ApiResultConst.MESSAGE(code));
        }

        public void SetResult(int code, bool isSuccessed, T data, string stackTrace, params string[] messages)
        {
            SetResult((ApiResultConst.CODE)code, isSuccessed, data, stackTrace, messages);
        }

        public void SetResult(ApiResultConst.CODE code, bool isSuccessed, T data, string stackTrace, params string[] messages)
        {
            Code = (int)code;
            IsSuccessed = isSuccessed;
            Data = data;
            StackTrace = stackTrace;

            Messages = new List<string>();
            foreach (var mess in messages)
            {
                Messages.Add(mess);
            }
        }

        public void SetResult(int code, bool isSuccessed, T data, string stackTrace, List<string> messages)
        {
            SetResult((ApiResultConst.CODE)code, isSuccessed, data, stackTrace, messages);
        }

        public void SetResult(ApiResultConst.CODE code, bool isSuccessed, T data, string stackTrace, List<string> messages)
        {
            Code = (int)code;
            IsSuccessed = isSuccessed;
            Data = data;
            StackTrace = stackTrace;

            Messages = new List<string>();
            foreach (var mess in messages)
            {
                Messages.Add(mess);
            }
        }
    }

    public static class DefaultApiResult
    {
        public static ApiResult<T> GetExceptionApiResult<T>(IWebHostEnvironment env, Exception ex, T defaultData)
        {
            var apiResult = new ApiResult<T>(defaultData);
            var stackTrace = "";
            if (env.IsDevelopment())
            {
                stackTrace = ex.StackTrace;
            }
            apiResult.SetResult(ApiResultConst.CODE.ERROR, false, defaultData, stackTrace);
            return apiResult;
        }
    }
}