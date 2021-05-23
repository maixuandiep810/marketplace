using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace marketplace.Utilities.Common
{
    public static class LogUtils
    {
        public static void LogException<T>(IWebHostEnvironment env, Exception ex, ILogger<T> logger, string message)
        {
            if (env.IsDevelopment())
            {
                logger.LogInformation(ex, message);
            }
        }
    }
}