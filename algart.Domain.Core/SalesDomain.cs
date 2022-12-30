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
    public class SalesDomain : ISalesDomain
    {
        private readonly ISalesRepository _Repository;
        public IConfiguration Configuration { get; }

        public SalesDomain(ISalesRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<string> InsertAsync(Sale model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<string> UpdateAsync(Sale model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            return await _Repository.DeleteAsync(Id);
        }

        public async Task<Sale> GetAsync(int? Id)
        {
            return await _Repository.GetAsync(Id);
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

    }
}
