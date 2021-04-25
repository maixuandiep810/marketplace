using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class LangNgheDanhMucRepository : GenericRepository<LangNgheDanhMuc, int>, ILangNgheDanhMucRepository
    {
        public LangNgheDanhMucRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }
    }
}