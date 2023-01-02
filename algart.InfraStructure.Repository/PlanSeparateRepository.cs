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
    public class PlanSeparateRepository : IPlanSeparateRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public PlanSeparateRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<PlanSeparate>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspGetPlanSeparate";
                var result = await connection.QueryAsync<PlanSeparate>(query, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

    }
}
