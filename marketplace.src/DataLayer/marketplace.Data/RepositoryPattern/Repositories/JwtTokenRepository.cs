// using System.Threading.Tasks;
// using System;
// using marketplace.Data.RepositoryPattern.IRepositories;
// using marketplace.Data.Entities;
// using marketplace.Data.EF;

// namespace marketplace.Data.RepositoryPattern.Repositories
// {
//     public class JwtTokenRepository : GenericRepository<JwtToken, int>, IJwtTokenRepository
//     {
//         public JwtTokenRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
//         {

//         }

//         public async Task<JwtToken> GetJwtTokenAsync(Guid userId, string token)
//         {
//             return await FirstOrDefaultAsync(x => x.Token == token && x.TaiKhoanId == userId);
//         }
//     }
// }