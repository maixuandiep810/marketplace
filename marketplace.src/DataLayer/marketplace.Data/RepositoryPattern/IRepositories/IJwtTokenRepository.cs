// using System.Threading.Tasks;
// using System;
// using marketplace.Data.RepositoryPattern.IRepositories;
// using marketplace.Data.Entities;
// using marketplace.Data.EF;

// namespace marketplace.Data.RepositoryPattern.IRepositories
// {
//     public interface IJwtTokenRepository : IGenericRepository<JwtToken, int>
//     {
//         Task<JwtToken> GetJwtTokenAsync(Guid userId, string token);
//     }
// }