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

        public ImageDTO(HinhAnh img)
        {
            Code = img.MaHA;
            Description = img.MoTa;
            Url = img.Url;
            Caption = img.TieuDe;
            IsDefault = img.LaAnhMacDinh;
            SortOrder = img.ThuTu;
        }

        public static ImageDTO HinhAnhToImageDTO(HinhAnh hinh)
        {
            return new ImageDTO(hinh);
        }
    }
}