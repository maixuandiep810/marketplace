using System.Collections.Generic;
using marketplace.Data.Entities;

namespace marketplace.DTO.Catalog.Address
{
    public class AreaDTO
    {
        public string Name { get; set; }
        public int TotalStore { get; set; }
        public List<ProvinceDTO> ProvinceDTOs { get; set; }

        public AreaDTO()
        {
            ProvinceDTOs = null;
        }

        public AreaDTO(CapVungMien capVungMien) : this()
        {
            Name = capVungMien.Ten;
            TotalStore = capVungMien.SoCuaHang;
            if (capVungMien.CapTinhs != null)
            {
                ProvinceDTOs = ProvinceDTO.GetProvinceDTOs(capVungMien.CapTinhs);
            }
        }

        public static List<AreaDTO> GetAreaDTOs(List<CapVungMien> capVungMiens)
        {
            var areaDTOs = new List<AreaDTO>();
            foreach (var item in capVungMiens)
            {
                areaDTOs.Add(new AreaDTO(item));
            }
            return areaDTOs;
        }
    }
}