using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace marketplace.Services.Common
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(IFormFile file, string folderName);
        Task DeleteFileAsync(string fileUrl);
    }
}