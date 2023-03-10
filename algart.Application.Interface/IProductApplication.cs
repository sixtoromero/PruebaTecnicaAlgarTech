using algart.Application.DTO;
using algart.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace algart.Application.Interface
{
    public interface IProductApplication
    {
        Task<Response<IEnumerable<ProductDTO>>> GetAllAsync();
        Task<Response<IEnumerable<ProductDTO>>> GetProductsBySaleDepartmentIdAsync(int SalesDepartmentId);
    }
}
