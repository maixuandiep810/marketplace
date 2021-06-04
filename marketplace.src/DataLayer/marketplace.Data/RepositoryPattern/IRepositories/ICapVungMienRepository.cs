using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.Data.Entities;

namespace marketplace.Data.RepositoryPattern.IRepositories
{
    public interface ICapVungMienRepository : IGenericRepository<CapVungMien, int>
    {
        Task<List<CapVungMien>> GetAllIncludeCapTinhsAsync();
    }
}