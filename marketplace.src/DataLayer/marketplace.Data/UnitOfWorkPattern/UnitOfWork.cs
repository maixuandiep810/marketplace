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
        private readonly IDbContextTransaction _contextTransaction;

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

        public ISanPhamRepository SanPhamRepository { get; }

        public ISanPhamDanhMucRepository SanPhamDanhMucRepository { get; }

        public ITaiKhoanRepository TaiKhoanRepository { get; }

        public IVaiTroRepository VaiTroRepository { get; }

        public UnitOfWork(marketplaceDbContext context)
        {
            _context = context;
            _contextTransaction = _context.Database.BeginTransaction();
            ChiTietSanPhamRepository = new ChiTietSanPhamRepository(_context);
            HinhAnhRepository = new HinhAnhRepository(_context);
            SanPhamRepository = new SanPhamRepository(_context);
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
        public async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                await _contextTransaction.CommitAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task RollbackTransactionAsync() {
            await _contextTransaction.RollbackAsync();
        }
    }
}