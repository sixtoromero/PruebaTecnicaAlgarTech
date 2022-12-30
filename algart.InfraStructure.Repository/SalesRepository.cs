using Dapper;
using algart.Domain.Entity;
using algart.InfraStructure.Interface;
using algart.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace algart.InfraStructure.Repository
{
    public class SalesRepository : ISalesRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public SalesRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Sale model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                var query = "uspSaleInsert";
                var parameters = new DynamicParameters();

                parameters.Add("Descripcion", model.Description);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspSaleDelete";
                var parameters = new DynamicParameters();

                parameters.Add("Id", Id);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetSale";
                var result = await connection.QueryAsync<Sale>(query, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<Sale> GetAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetCategoriaporId";
                var parameters = new DynamicParameters();

                parameters.Add("Id", Id);

                var result = await connection.QuerySingleAsync<Sale>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<string> UpdateAsync(Sale model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspSaleUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("Id", model.Id);
                //parameters.Add("Descripcion", model.Descripcion);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
