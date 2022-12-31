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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public CustomerRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspGetCustomer";
                var result = await connection.QueryAsync<Customer>(query, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

    }
}
