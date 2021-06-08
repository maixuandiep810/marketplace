using marketplace.Data.Entities;

namespace marketplace.DTO.Catalog.Address
{
    public class VillageDTO
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        // public string Description { get; set; }
        // public string Address { get; set; }

        public VillageDTO()
        {
            Name = "";
            FullName = "";
        }

        public VillageDTO(LangNghe langNghe)
        {
            Name = langNghe.Ten;
            FullName = langNghe.TenDayDu;
        }
    }
}