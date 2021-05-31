using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using marketplace.Data.UnitOfWorkPattern;
using marketplace.DTO.Catalog.Product;
using marketplace.DTO.Common;
using Microsoft.Extensions.Configuration;
using marketplace.Utilities.Const;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using marketplace.Services.Common;
using System;
using marketplace.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using marketplace.DTO.Catalog.Category;
using Microsoft.Extensions.Logging;
using marketplace.Utilities.Common;
using marketplace.Services.Utils;

namespace marketplace.Services.Catalog.Store
{
    public class StoreService : BaseService<StoreService>, IStoreService
    {
        private readonly IImageService _imageService;
        
        public StoreService(IImageService imageService,
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            ILogger<StoreService> logger) : base(configuration, unitOfWork, env, logger)
        {
            _imageService = imageService;
        }
    }
}