using System.Data.Common;
using System;
using System.Threading.Tasks;
using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.EF;
using marketplace.Data.RepositoryPattern.Repositories;
using marketplace.Data.UnitOfWorkPattern;
using Microsoft.EntityFrameworkCore.Storage;

namespace marketplace.Data.UnitOfWorkPattern

{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;
        private readonly marketplaceDbContext _context;


        public ICapTinhRepository CapTinhRepository { get; }
        public ICapHuyenRepository CapHuyenRepository { get; }
        public ICapXaRepository CapXaRepository { get; }


        public IChiTietDonHangRepository ChiTietDonHangRepository { get; }

        public ICuaHangRepository CuaHangRepository { get; }

        public IDanhMucRepository DanhMucRepository { get; }

        public IChiTietDanhMucRepository ChiTietDanhMucRepository { get; }

        public IChiTietSanPhamRepository ChiTietSanPhamRepository { get; }

        public IDonHangRepository DonHangRepository { get; }

        public IGiaoDichRepository GiaoDichRepository { get; }

        public IGioHangRepository GioHangRepository { get; }

        public IHinhAnhRepository HinhAnhRepository { get; }

        public IKhachHangRepository KhachHangRepository { get; }

        public ILangNgheRepository LangNgheRepository { get; }

        public ILangNgheDanhMucRepository LangNgheDanhMucRepository { get; }

        public INgonNguRepository NgonNguRepository { get; }

        public INguoiBanRepository NguoiBanRepository { get; }

        public IQuanLyDonHangRepository QuanLyDonHangRepository { get; }

        // public IQuyenEntityRepository QuyenEntityRepository { get; }
        // public IQuyenEntityTaiKhoanRepository QuyenEntityTaiKhoanRepository { get; }
        // public IQuyenEntityVaiTroRepository QuyenEntityVaiTroRepository { get; }
        public IQuyenRouteRepository QuyenRouteRepository { get; }
        public IQuyenRouteVaiTroRepository QuyenRouteVaiTroRepository { get; }

        public ISanPhamRepository SanPhamRepository { get; }

        public ISanPhamDanhMucRepository SanPhamDanhMucRepository { get; }

        public ITaiKhoanRepository TaiKhoanRepository { get; }

        public IVaiTroRepository VaiTroRepository { get; }

        public UnitOfWork(marketplaceDbContext context)
        {
            _context = context;
            CapTinhRepository = new CapTinhRepository(_context);
            CapHuyenRepository = new CapHuyenRepository(_context);
            CapXaRepository = new CapXaRepository(_context);
            ChiTietDanhMucRepository = new ChiTietDanhMucRepository(_context);
            ChiTietDonHangRepository = new ChiTietDonHangRepository(_context);
            ChiTietSanPhamRepository = new ChiTietSanPhamRepository(_context);
            CuaHangRepository = new CuaHangRepository(_context);
            DanhMucRepository = new DanhMucRepository(_context);
            DonHangRepository = new DonHangRepository(_context);
            GiaoDichRepository = new GiaoDichRepository(_context);
            GioHangRepository = new GioHangRepository(_context);
            HinhAnhRepository = new HinhAnhRepository(_context);
            KhachHangRepository = new KhachHangRepository(_context);
            LangNgheDanhMucRepository = new LangNgheDanhMucRepository(_context);
            LangNgheRepository = new LangNgheRepository(_context);
            NgonNguRepository = new NgonNguRepository(_context);
            NguoiBanRepository = new NguoiBanRepository(_context);
            NguoiBanRepository = new NguoiBanRepository(_context);
            QuanLyDonHangRepository = new QuanLyDonHangRepository(_context);
            // QuyenEntityRepository = new QuyenEntityRepository(_context);
            // QuyenEntityTaiKhoanRepository = new QuyenEntityTaiKhoanRepository(_context);
            // QuyenEntityVaiTroRepository = new QuyenEntityVaiTroRepository(_context);
            QuyenRouteRepository = new QuyenRouteRepository(_context);
            QuyenRouteVaiTroRepository = new QuyenRouteVaiTroRepository(_context);
            SanPhamRepository = new SanPhamRepository(_context);
            SanPhamDanhMucRepository = new SanPhamDanhMucRepository(_context);
            TaiKhoanRepository = new TaiKhoanRepository(_context);
            VaiTroRepository = new VaiTroRepository(_context);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// TODO: 
        /// 1.<!-- Dispose ALL REPOSITORY-->
        /// </summary>
        /// <param name="disposing"></param>
        /// 
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // TODO-1
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        /// <summary>
        /// Save All Changes To Db using DbContext
        /// </summary>
        /// <returns></returns>
        /// 
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}