using algart.Application.DTO;
using algart.Application.Interface;
using algart.Domain.Entity;
using algart.Domain.Interface;
using algart.Transversal.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace algart.Application.Main
{
    public class CategoriasApplication : ICategoriasApplication
    {
        private readonly ICategoriasDomain _Domain;
        private readonly IMapper _mapper;

        public CategoriasApplication(ICategoriasDomain catDomain, IMapper mapper)
        {
            _Domain = catDomain;
            _mapper = mapper;
        }        

        public async Task<Response<string>> InsertAsync(CategoriasDTO modelDto)
        {
            var response = new Response<string>();
            try
            {
                var resp = _mapper.Map<Categorias>(modelDto);
                response.Data = await _Domain.InsertAsync(resp);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Data = string.Empty;
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<string>> UpdateAsync(CategoriasDTO modelDto)
        {
            var response = new Response<string>();
            try
            {
                var resp = _mapper.Map<Categorias>(modelDto);
                response.Data = await _Domain.UpdateAsync(resp);
                if (response.Data == "success")
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Data = string.Empty;
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<string>> DeleteAsync(int ID)
        {
            var response = new Response<string>();
            try
            {
                response.Data = await _Domain.DeleteAsync(ID);
                if (response.Data == "success")
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<CategoriasDTO>> GetAsync(int ID)
        {
            var response = new Response<CategoriasDTO>();
            try
            {
                var result = await _Domain.GetAsync(ID);

                response.Data = _mapper.Map<CategoriasDTO>(result);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<IEnumerable<CategoriasDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CategoriasDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<CategoriasDTO>>(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;                
            }

            return response;
        }                
    }
}
