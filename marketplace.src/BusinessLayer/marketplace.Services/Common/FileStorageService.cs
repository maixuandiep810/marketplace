using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using marketplace.Utilities.Const;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace marketplace.Services.Common
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _userContentRootFolder;

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _userContentRootFolder = Path.Combine(webHostEnvironment.WebRootPath);
        }

        private string GetFileUrl(string folderName, string fileName)
        {
            return $"{folderName}/{fileName}";
        }

        private async Task SaveFileAsync(Stream mediaBinaryStream, string fileUrl)
        {
            try
            {
                var filePath = Path.Combine(_userContentRootFolder, fileUrl);
                using var output = new FileStream(filePath, FileMode.Create);
                await mediaBinaryStream.CopyToAsync(output);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<string> SaveFileAsync(IFormFile file, string folderName)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            string fileUrl = GetFileUrl(folderName, fileName);
            await SaveFileAsync(file.OpenReadStream(), fileUrl);
            return fileUrl;
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