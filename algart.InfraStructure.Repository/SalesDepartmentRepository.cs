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
    public class SalesDepartmentRepository : ISalesDepartmentRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public SalesDepartmentRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<SalesDepartment>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspGetSalesDepartment";
                var result = await connection.QueryAsync<SalesDepartment>(query, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
