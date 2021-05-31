using System;
using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class TaiKhoanRepository : GenericRepository<TaiKhoan, Guid>, ITaiKhoanRepository
    {
        public TaiKhoanRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {
        
        }
    }
}