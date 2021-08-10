using Dapper;
using Microsoft.Extensions.Options;
using Bamboo.Application.Infrastructure.Repository;
using Bamboo.Application.JsonModels;
using Bamboo.DataAccess.Unitofwork;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bamboo.Application.Constants;
using Bamboo.DataAccess.Repositories.Product;
using Bamboo.Domain.Entities;

namespace Bamboo.DataAccess.Repositories.Department
{
    public class OrderRepository : IAsyncOrderRepository
    {
        private readonly ConnectionStrings _connectionStrings;

        public OrderRepository(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        public async Task<List<Domain.Entities.OrderEntity>> GetAllAsync()
        {
            using (var unitOfWork = new DapUnitOfWork(_connectionStrings.BAMBOO, Databases.BAMBOO))
            {
                var sqlQuery = OrderQuery.GET_ALL;
                var result = await unitOfWork.OrderRepository.GetAllAsync(sqlQuery, null);
                return result;
            }
        }

        public async Task<Domain.Entities.OrderEntity> GetByIdAsync(long Id)
        {
            using (var unitOfWork = new DapUnitOfWork(_connectionStrings.BAMBOO, Databases.BAMBOO))
            {
                var sqlQuery = OrderQuery.GET_BY_ID;
                var parameter = new DynamicParameters();
                parameter.Add("@Id", Id);
                var result = await unitOfWork.OrderRepository.GetSingleAsync(sqlQuery, parameter);
                return result;
            }
        }

        public async Task AddAsync(Order model)
        {
            using (var unitOfWork = new DapUnitOfWork(_connectionStrings.BAMBOO, Databases.BAMBOO))
            {
                var sqlQuery = OrderQuery.INSERT;
                var entity = new OrderEntity();
                if (model.Products != null && model.Products.Count > 1)
                {
                    foreach (var item in model.Products)
                    {
                        entity.AccountId = model.AccountId;
                        entity.RequestID = model.RequestID;
                        entity.ProductId = item.ProductId;
                        entity.Quantity = item.Quantity;
                        entity.Value = item.Value;
                    }
                }

                var result = await unitOfWork.OrderRepository.ExecuteAsync(sqlQuery, entity);
                unitOfWork.Commit();
            }
        }

    }
}
