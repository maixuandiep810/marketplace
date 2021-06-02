using marketplace.Data.Entities;
using marketplace.DTO.Enum;

namespace marketplace.DTO.Catalog.Branch
{
    public class BranchDTO
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public Status Status { get; set; }

        public string BranchCode { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public BranchDTO()
        {

        }

        public BranchDTO(LangNghe langNghe)
        {
            if (langNghe != null)
            {
                Id = langNghe.Id;
                IsDeleted = langNghe.DaXoa;
                Status = (Status) langNghe.TrangThai;

                Name = langNghe.Ten;
                FullName = langNghe.TenDayDu;
                Description = langNghe.MoTa;
                Address = langNghe.DiaChi;
            }
        }
    }
}