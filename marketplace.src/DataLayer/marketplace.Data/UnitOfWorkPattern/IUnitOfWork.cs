using System;
using System.Threading.Tasks;
using marketplace.Data.RepositoryPattern.IRepositories;

namespace marketplace.Data.UnitOfWorkPattern
{
    public interface IUnitOfWork : IDisposable
    {
        ICapTinhRepository CapTinhRepository { get; }
        ICapHuyenRepository CapHuyenRepository { get; }
        ICapXaRepository CapXaRepository { get; }

        IChiTietDonHangRepository ChiTietDonHangRepository { get; }
        ICuaHangRepository CuaHangRepository { get; }
        IDanhMucRepository DanhMucRepository { get; }
        IChiTietDanhMucRepository ChiTietDanhMucRepository { get; }
        IChiTietSanPhamRepository ChiTietSanPhamRepository { get; }
        IDonHangRepository DonHangRepository { get; }
        IGiaoDichRepository GiaoDichRepository { get; }
        IGioHangRepository GioHangRepository { get; }
        IHinhAnhRepository HinhAnhRepository { get; }
        IKhachHangRepository KhachHangRepository { get; }
        ILangNgheRepository LangNgheRepository { get; }
        ILangNgheDanhMucRepository LangNgheDanhMucRepository { get; }
        INgonNguRepository NgonNguRepository { get; }
        INguoiBanRepository NguoiBanRepository { get; }
        IQuanLyDonHangRepository QuanLyDonHangRepository { get; }

        // IQuyenEntityRepository QuyenEntityRepository { get; }
        // IQuyenEntityTaiKhoanRepository QuyenEntityTaiKhoanRepository { get; }
        // IQuyenEntityVaiTroRepository QuyenEntityVaiTroRepository { get; }
        IQuyenRouteRepository QuyenRouteRepository { get; }
        IQuyenRouteVaiTroRepository QuyenRouteVaiTroRepository { get; }

        ISanPhamRepository SanPhamRepository { get; }
        ISanPhamDanhMucRepository SanPhamDanhMucRepository { get; }
        ITaiKhoanRepository TaiKhoanRepository { get; }
        IVaiTroRepository VaiTroRepository { get; }


        Task SaveChangesAsync();
    }
}