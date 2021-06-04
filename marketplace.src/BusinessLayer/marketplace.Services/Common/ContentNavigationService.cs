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
using marketplace.DTO.Catalog.Branch;
using marketplace.DTO.Catalog.Address;
using marketplace.DTO.Component;

namespace marketplace.Services.Common
{
    public class ContentNavigationService : BaseService<ContentNavigationService>, IContentNavigationService
    {
        public ContentNavigationService(
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            ILogger<ContentNavigationService> logger) : base(configuration, unitOfWork, env, logger)
        {
        }

        public async Task<ContentNavigationDTO> GetNavigationAsync(string type, string provinceUrl, string districUrl)
        {
            try
            {
                var contentNavigationDTO = new ContentNavigationDTO();
                switch (type)
                {
                    case "province":
                        var entity = await _unitOfWork.CapTinhRepository.GetByUrl(provinceUrl);
                        var navigationDTO = new NavigationDTO();
                        navigationDTO.Name = entity.Ten;
                        navigationDTO.Url = entity.TenUrlDayDu;
                        contentNavigationDTO.NavigationDTO.Add(navigationDTO);
                        break;
                    default:
                        break;
                }
                return contentNavigationDTO;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}