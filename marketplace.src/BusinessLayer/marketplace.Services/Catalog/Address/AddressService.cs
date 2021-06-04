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

namespace marketplace.Services.Catalog.Address
{
    public class AddressService : BaseService<AddressService>, IAddressService
    {
        public AddressService(
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            ILogger<AddressService> logger) : base(configuration, unitOfWork, env, logger)
        {
        }












        public async Task<ApiResult<List<AreaDTO>>> GetAllAreaDTOAsync()
        {
            try
            {
                var areas = await _unitOfWork.CapVungMienRepository.GetAllIncludeCapTinhsAsync();
                if (areas == null)
                {
                    return new ApiResult<List<AreaDTO>>(ApiResultConst.CODE.ENTITY_NOT_FOUND_E, false, null, null);
                }
                var areaDTOs = AreaDTO.GetAreaDTOs(areas);
                return new ApiResult<List<AreaDTO>>(ApiResultConst.CODE.SUCCESS, true, areaDTOs, null);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}