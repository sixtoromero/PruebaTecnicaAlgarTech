using algart.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace algart.Domain.Interface
{
    public interface IProductDomain
    {
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
