using Bamboo.DataAccess.Common;
using Bamboo.Domain.Entities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Bamboo.DataAccess.Unitofwork
{
    public class DapUnitOfWork : IDisposable
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        /// <summary>
        /// NpgsqlConnection is for PostgreSQL
        /// SqlConnection is for MSSQL
        /// </summary>
        /// <param name="connectionString"></param>
        public DapUnitOfWork(string connectionString, string dbName = "")
        {
            //_connection = new NpgsqlConnection(connectionString);
            _connection = new SqlConnection(connectionString);
            _connection.Open();

            if (!string.IsNullOrEmpty(dbName))
            {
                _connection.ChangeDatabase(dbName);
            }
            _transaction = _connection.BeginTransaction();
        }

        #region Setting repository forEntities

        #region Declaration       
        private BaseRepositoryAsync<Product> _productRepository = null;
        private BaseRepositoryAsync<OrderEntity> _orderRepository = null;
        #endregion


        #region Implementation   

        public BaseRepositoryAsync<Product> ProductRepository
        {
            get
            {
                return _productRepository ?? (_productRepository = new BaseRepositoryAsync<Product>(_transaction));
            }
        }

        public BaseRepositoryAsync<OrderEntity> OrderRepository
        {
            get
            {
                return _orderRepository ?? (_orderRepository = new BaseRepositoryAsync<OrderEntity>(_transaction));
            }
        }



        #endregion

        #region Re-setting
        /// <summary>
        /// When we commit changes, we will be on a new transaction, so  to re-instantiate our repositories we should reset them.        
        /// </summary>
        private void ResetRepositories()
        {
            _productRepository = null;
            _orderRepository = null;
        }
        #endregion


        #endregion



        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }


        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }

    }
}
