using marketplace.Data.Entities;
using marketplace.DTO.Catalog.Address;
using marketplace.DTO.Common;

namespace marketplace.DTO.Catalog.Store
{
    public class StoreDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Description{ get; set; }
        public string Address { get; set; }
        public VillageDTO VillageDTO { get; set; }

        public ImageDTO ImageDTO { get; set; }

        public StoreDTO()
        {
            
        }

        public StoreDTO(CuaHang cuaHang)
        {
            Name = cuaHang.Ten;
            FullName = cuaHang.TenDayDu;
            VillageDTO = new VillageDTO(cuaHang.LangNghe);
            
        }
    }
}