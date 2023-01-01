using algart.Domain.Entity;
using algart.InfraStructure.Interface;
using algart.Transversal.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace algart.InfraStructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ProductRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspGetProducts";
                var result = await connection.QueryAsync<Product>(query, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<Product>> GetProductsBySaleDepartmentIdAsync(int SalesDepartmentId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspGetProductsBySaleDepartmentId";
                var parameters = new DynamicParameters();
                parameters.Add("SalesDepartmentId", SalesDepartmentId);

                var result = await connection.QueryAsync<Product>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }            
        }        
    }
}
