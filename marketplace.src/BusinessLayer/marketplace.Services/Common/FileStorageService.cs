using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using marketplace.Data.UnitOfWorkPattern;
using marketplace.Utilities.Const;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace marketplace.Services.Common
{
    public class FileStorageService : BaseService<FileStorageService>, IFileStorageService
    {
        private readonly string _userContentRootFolder;
        protected readonly IHttpClientFactory _httpClientFactory;


        public FileStorageService(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            ILogger<FileStorageService> logger) : base(configuration, unitOfWork, env, logger)
        {
            _userContentRootFolder = Path.Combine(_env.WebRootPath);
            _httpClientFactory = httpClientFactory;
        }

        private string GetRelativeFilePath(string folderName, string fileName)
        {
            return $"{folderName}/{fileName}";
        }

        private async Task SaveFileAsync(Stream mediaBinaryStream, string fileUrl)
        {
            var filePath = Path.Combine(_userContentRootFolder, fileUrl);
            if (File.Exists(filePath))
            {
                throw new Exception($"The FileName {filePath} is already exist");
            }
            // tạo mới, nếu file đang có bị ghi đè
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }

        public async Task<string> SaveFileAsync(IFormFile file, string relativeFolderPath)
        {
            try
            {
                var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
                string relativeFilePath = GetRelativeFilePath(relativeFolderPath, fileName);
                await SaveFileAsync(file.OpenReadStream(), relativeFilePath);
                return _configuration[ConfigKeyConst.BASE_API_ADDRESS] + "/" + relativeFilePath;
            }
            catch (System.Exception)
            {
                return "";
            }
        }

        public async Task<string> DownloadFileAsync(string url, string relativeFolderPath)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(url)}";
                string relativeFilePath = GetRelativeFilePath(relativeFolderPath, fileName);
                var absoluteFilePath = Path.Combine(_userContentRootFolder, relativeFilePath);
                using (var response = await client.GetAsync(url))
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        if (System.IO.File.Exists(absoluteFilePath))
                        {
                            throw new Exception($"The FileName {absoluteFilePath} is already exist");
                        }
                        // tạo mới, nếu file đang có bị ghi đè
                        using var output = new FileStream(absoluteFilePath, FileMode.Create);
                        await stream.CopyToAsync(output);
                    }
                }
                return _configuration[ConfigKeyConst.BASE_API_ADDRESS] + "/" + relativeFilePath;
            }
            catch (System.Exception)
            {
                return "";
            }
        }

        public async Task DeleteFileAsync(string fileUrl)
        {
            try
            {
                var filePath = Path.Combine(_userContentRootFolder, fileUrl);
                if (File.Exists(filePath))
                {
                    await Task.Run(() => File.Delete(filePath));
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}