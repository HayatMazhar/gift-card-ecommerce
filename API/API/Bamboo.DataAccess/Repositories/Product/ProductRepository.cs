using Dapper;
using Microsoft.Extensions.Options;
using Bamboo.Application.Infrastructure.Repository;
using Bamboo.Application.JsonModels;
using Bamboo.DataAccess.Unitofwork;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bamboo.Application.Constants;
using Bamboo.DataAccess.Repositories.Product;

namespace Bamboo.DataAccess.Repositories.Department
{
    public class ProductRepository : IAsyncProductRepository
    {
        private readonly ConnectionStrings _connectionStrings;

        public ProductRepository(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        public async Task<List<Domain.Entities.Product>> GetAllAsync()
        {
            using (var unitOfWork = new DapUnitOfWork(_connectionStrings.BAMBOO, Databases.BAMBOO))
            {
                var sqlQuery = ProductQuery.GET_ALL;
                var result = await unitOfWork.ProductRepository.GetAllAsync(sqlQuery, null);
                return result;
            }
        }

        public async Task<Domain.Entities.Product> GetByIdAsync(long Id)
        {
            using (var unitOfWork = new DapUnitOfWork(_connectionStrings.BAMBOO, Databases.BAMBOO))
            {
                var sqlQuery = ProductQuery.GET_BY_ID;
                var parameter = new DynamicParameters();
                parameter.Add("@Id", Id);
                var result = await unitOfWork.ProductRepository.GetSingleAsync(sqlQuery, parameter);
                return result;
            }
        }

        public async Task AddAsync(Domain.Entities.Product model)
        {
            using (var unitOfWork = new DapUnitOfWork(_connectionStrings.BAMBOO, Databases.BAMBOO))
            {
                var sqlQuery = ProductQuery.INSERT;
                var result = await unitOfWork.ProductRepository.ExecuteAsync(sqlQuery, model);
                unitOfWork.Commit();
            }
        }

        public async Task DeleteAsync(long Id)
        {
            using (var unitOfWork = new DapUnitOfWork(_connectionStrings.BAMBOO, Databases.BAMBOO))
            {
                var parameter = new DynamicParameters();
                var sqlQuery = ProductQuery.DELETE;
                parameter.Add("@Id", Id);
                var result = await unitOfWork.ProductRepository.ExecuteAsync(sqlQuery, parameter);
                unitOfWork.Commit();
            }
        }

        public async Task UpdateAsync(Domain.Entities.Product model)
        {
            using (var unitOfWork = new DapUnitOfWork(_connectionStrings.BAMBOO, Databases.BAMBOO))
            {
                var sqlQuery = ProductQuery.UPDATE;
                var result = await unitOfWork.ProductRepository.ExecuteAsync(sqlQuery, model);
                unitOfWork.Commit();
            }
        }

        
    }
}
