using System;
using System.Threading.Tasks;
using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.EF;
using marketplace.Data.RepositoryPattern.Repositories;
using marketplace.Data.UnitOfWorkPattern;

namespace vigalileo.Data.UnitOfWorkPattern

{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;
        private readonly marketplaceDbContext _context;

        public IChiTietDonHangRepository ChiTietDonHangRepository { get; }

        public ICuaHangRepository CuaHangRepository { get; }

        public IDanhMucRepository DanhMucRepository { get; }

        public IDanhMucDichThuatRepository DanhMucDichThuatRepository { get; }

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

        public ISanPhamRepository SanPhamRepository { get; }

        public ISanPhamDanhMucRepository SanPhamDanhMucRepository { get; }

        public ISanPhamDichThuatRepository SanPhamDichThuatRepository { get; }

        public ITaiKhoanRepository TaiKhoanRepository { get; }

        public IVaiTroRepository VaiTroRepository { get; }

        public UnitOfWork(marketplaceDbContext context)
        {
            _context = context;;
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
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        // public void Rollback()
        // {
        //     _context
        //         .ChangeTracker
        //         .Entries()
        //         .ToList()
        //         .ForEach(x => x.Reload());
        // }
    }
}