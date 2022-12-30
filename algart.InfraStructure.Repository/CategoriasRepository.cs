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
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public CategoriasRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Categorias model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspCategoriasInsert";
                var parameters = new DynamicParameters();

                parameters.Add("Descripcion", model.Descripcion);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;

            }
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspCategoriasDelete";
                var parameters = new DynamicParameters();

                parameters.Add("Id", Id);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<Categorias>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetCategorias";
                var result = await connection.QueryAsync<Categorias>(query, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<Categorias> GetAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetCategoriaporId";
                var parameters = new DynamicParameters();

                parameters.Add("Id", Id);

                var result = await connection.QuerySingleAsync<Categorias>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }        

        public async Task<string> UpdateAsync(Categorias model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspCategoriasUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("Id", model.Id);
                parameters.Add("Descripcion", model.Descripcion);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
