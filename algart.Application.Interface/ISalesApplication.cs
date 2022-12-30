using algart.Application.DTO;
using algart.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace algart.Application.Interface
{
    public interface ISalesApplication
    {
        Task<Response<string>> InsertAsync(SaleDTO modelDto);
        Task<Response<string>> UpdateAsync(SaleDTO modelDto);
        Task<Response<string>> DeleteAsync(int Id);
        Task<Response<SaleDTO>> GetAsync(int IDUsuario);
        Task<Response<IEnumerable<SaleDTO>>> GetAllAsync();
    }
}
