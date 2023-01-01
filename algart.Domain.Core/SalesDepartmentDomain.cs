using algart.Domain.Entity;
using algart.Domain.Interface;
using algart.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace algart.Domain.Core
{
    public class SalesDepartmentDomain : ISalesDepartmentDomain
    {
        private readonly ISalesDepartmentRepository _Repository;
        public IConfiguration Configuration { get; }

        public SalesDepartmentDomain(ISalesDepartmentRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<IEnumerable<SalesDepartment>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }
    }
}
