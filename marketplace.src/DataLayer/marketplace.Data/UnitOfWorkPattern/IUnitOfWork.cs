using System;
using System.Threading.Tasks;
using marketplace.Data.RepositoryPattern.IRepositories;

namespace marketplace.Data.UnitOfWorkPattern
{
    public interface IUnitOfWork : IDisposable
    {
        IChiTietDonHangRepository ChiTietDonHangRepository { get; }
        ICuaHangRepository CuaHangRepository { get; }
        IDanhMucRepository DanhMucRepository { get; }
        IDanhMucDichThuatRepository DanhMucDichThuatRepository { get; }
        IDonHangRepository DonHangRepository { get; }
        IGiaoDichRepository GiaoDichRepository { get; }
        IGioHangRepository GioHangRepository { get; }
        IHinhAnhRepository HinhAnhRepository { get; }
        IKhachHangRepository KhachHangRepository { get; }
        ILangNgheRepository LangNgheRepository { get; }
        ILangNgheDanhMucRepository LangNgheDanhMucRepository { get; }
        INgonNguRepository NgonNguRepository { get; }
        INguoiBanRepository NguoiBanRepository{ get; }
        IQuanLyDonHangRepository QuanLyDonHangRepository { get; }
        ISanPhamRepository SanPhamRepository { get; }
        ISanPhamDanhMucRepository SanPhamDanhMucRepository { get; }
        ISanPhamDichThuatRepository SanPhamDichThuatRepository { get; }
        ITaiKhoanRepository TaiKhoanRepository { get; }
        IVaiTroRepository VaiTroRepository { get; }


        Task CommitAsync();
    }
}