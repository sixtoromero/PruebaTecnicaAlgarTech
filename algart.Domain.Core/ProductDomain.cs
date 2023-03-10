using algart.Domain.Entity;
using algart.Domain.Interface;
using algart.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace algart.Domain.Core
{
    public class ProductDomain : IProductDomain
    {
        private readonly IProductRepository _Repository;
        public IConfiguration Configuration { get; }

        public ProductDomain(IProductRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsBySaleDepartmentIdAsync(int SalesDepartmentId)
        {
            return await _Repository.GetProductsBySaleDepartmentIdAsync(SalesDepartmentId);
        }
    }
}
