using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace marketplace.BackendApi.Extensions
{
    public static class MPHttpContextExtensions
    {

        public static async Task WriteJsonResponseAsync(this HttpContext httpContext, int statusCode, object jsonObject)
        {
            var jsonResult = JsonSerializer.Serialize(jsonObject);
            httpContext.Response.StatusCode = statusCode;
            // Set the content type
            httpContext.Response.ContentType = "application/json; charset=utf-8";
            await httpContext.Response.WriteAsync(jsonResult);
        }
    }
}





// public static async Task WriteJsonResponseAsync(this HttpContext context, JsonOptions options, int statusCode, object jsonObject)
// {

//     // https://github.com/dotnet/aspnetcore/issues/19891
//     // Serialize using the settings provided
//     using MemoryStream stream = new MemoryStream();
//     await JsonSerializer.SerializeAsync(stream, jsonObject, typeof(SomeGenericType), options.JsonSerializerOptions);
//     ReadOnlyMemory<byte> readOnlyMemory = new ReadOnlyMemory<byte>(stream.ToArray());

//     // Set the status code
//     context.Response.StatusCode = statusCode;

//     // Set the content type
//     context.Response.ContentType = "application/json; charset=utf-8";

//     // Write the content
//     await context.Response.Body.WriteAsync(readOnlyMemory);
//     await context.Response.Body.FlushAsync();
// }
