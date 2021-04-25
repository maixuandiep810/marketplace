using System.Linq;
using System;
using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class ChiTietDonHangRepository : GenericRepository<ChiTietDonHang, int>, IChiTietDonHangRepository
    {
        public ChiTietDonHangRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }
    }
}