using marketplace.Data.Entities;

namespace marketplace.DTO.Common
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public int SortOrder { get; set; }

        public ImageDTO()
        {

        }

        public ImageDTO(HinhAnh image) : this()
        {
            if (image != null)
            {
                Code = image.MaSo;
                Description = image.MoTa;
                Url = image.Url;
                Caption = image.TieuDe;
                IsDefault = image.LaAnhMacDinh;
                SortOrder = image.ThuTu;
            }
        }
    }
}