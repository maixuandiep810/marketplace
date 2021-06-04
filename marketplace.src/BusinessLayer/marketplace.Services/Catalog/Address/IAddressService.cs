using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.DTO.Catalog.Address;
using marketplace.DTO.Common;
using marketplace.DTO.Component;

namespace marketplace.Services.Catalog.Address
{
    public interface IAddressService
    {
        Task<List<AreaDTO>> GetAllAreaDTOAsync();
    }
}