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
    }
}
