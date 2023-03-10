using algart.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace algart.InfraStructure.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsBySaleDepartmentIdAsync(int SalesDepartmentId);
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
