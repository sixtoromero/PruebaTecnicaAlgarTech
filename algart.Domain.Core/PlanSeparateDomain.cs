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
    public class PlanSeparateDomain : IPlanSeparateDomain
    {
        private readonly IPlanSeparateRepository _Repository;
        public IConfiguration Configuration { get; }

        public PlanSeparateDomain(IPlanSeparateRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<IEnumerable<PlanSeparate>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }
    }
}
