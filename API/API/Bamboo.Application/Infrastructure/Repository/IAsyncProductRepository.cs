using Bamboo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bamboo.Application.Infrastructure.Repository
{
    public interface IAsyncProductRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(long Id);

        Task AddAsync(Product model);

        Task DeleteAsync(long Id);
    }
}
