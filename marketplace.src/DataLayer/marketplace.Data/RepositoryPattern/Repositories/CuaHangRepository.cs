using System;
using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class CuaHangRepository : GenericRepository<CuaHang, int>, ICuaHangRepository
    {
        public CuaHangRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }

        public async Task<CuaHang> GetBySellerIdAsync(string userId) {
            return await _context.NguoiBans.Where(x => x.TaiKhoanId == (new Guid(userId))).Include(x => x.CuaHang).ThenInclude(x => x.LangNghe).Select(x => x.CuaHang).FirstOrDefaultAsync();
        }
    }
}