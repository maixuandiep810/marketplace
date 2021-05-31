using System;
using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class CapHuyenRepository : GenericRepository<CapHuyen, int>, ICapHuyenRepository
    {
        public CapHuyenRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }
    }
}