using marketplace.Data.UnitOfWorkPattern;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace marketplace.Services
{
    public class BaseService<T>
    {
        protected readonly IConfiguration _configuration;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IWebHostEnvironment _env;
        protected readonly ILogger<T> _logger;

        public BaseService(IConfiguration configuration, IUnitOfWork unitOfWork, IWebHostEnvironment env, ILogger<T> logger)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _env = env;
            _logger = logger;
        }
    }
}