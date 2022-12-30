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
    public class CategoriasDomain : ICategoriasDomain
    {
        private readonly ICategoriasRepository _Repository;
        public IConfiguration Configuration { get; }

        public CategoriasDomain(ICategoriasRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }       
        
        public async Task<string> InsertAsync(Categorias model)
        {
            return await _Repository.InsertAsync(model);
        }
        
        public async Task<string> UpdateAsync(Categorias model)
        {
            return await _Repository.UpdateAsync(model);
        }
        
        public async Task<string> DeleteAsync(int? Id)
        {
            return await _Repository.DeleteAsync(Id);
        }
        
        public async Task<Categorias> GetAsync(int? Id)
        {
            return await _Repository.GetAsync(Id);
        }
        
        public async Task<IEnumerable<Categorias>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }               
    }

}
