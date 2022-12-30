using algart.Application.DTO;
using algart.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace algart.Application.Interface
{
    public interface ICategoriasApplication
    {
        Task<Response<string>> InsertAsync(CategoriasDTO modelDto);
        Task<Response<string>> UpdateAsync(CategoriasDTO modelDto);
        Task<Response<string>> DeleteAsync(int Id);
        Task<Response<CategoriasDTO>> GetAsync(int IDUsuario);
        Task<Response<IEnumerable<CategoriasDTO>>> GetAllAsync();

    }
}
