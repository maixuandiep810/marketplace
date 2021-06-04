using System.Collections.Generic;
using marketplace.Data.Entities;

namespace marketplace.DTO.Catalog.Address
{
    public class ProvinceDTO
    {
        public string Name { get; set; }
        public string RelativeUrl { get; set; }
        public int TotalStore { get; set; }

        public ProvinceDTO()
        {

        }

        public ProvinceDTO(CapTinh capTinh) : this()
        {
                Name = capTinh.Ten;
                RelativeUrl = capTinh.TenUrlDayDu;
                TotalStore = capTinh.SoCuaHang;
        }

        public static List<ProvinceDTO> GetProvinceDTOs(List<CapTinh> capTinhs) {
            var provinceDTOs = new List<ProvinceDTO>();
            foreach (var item in capTinhs)
            {
                provinceDTOs.Add(new ProvinceDTO(item));
            }
            return provinceDTOs;
        }
    }
}