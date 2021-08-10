using Bamboo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bamboo.Application.Infrastructure.Repository
{
    public interface IAsyncOrderRepository
    {
        Task<List<OrderEntity>> GetAllAsync();

        Task<OrderEntity> GetByIdAsync(long Id);
        
        Task AddAsync(Order model);
        
    }
}
