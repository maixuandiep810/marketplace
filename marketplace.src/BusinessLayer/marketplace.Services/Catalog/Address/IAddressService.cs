using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.DTO.Catalog.Address;
using marketplace.DTO.Common;

namespace marketplace.Services.Catalog.Address
{
    public interface IAddressService
    {
        Task<ApiResult<List<AreaDTO>>> GetAllAreaDTOAsync();
    }
}