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
    public class SalesApplication : ISalesApplication
    {
        private readonly ISalesDomain _Domain;
        private readonly IMapper _mapper;

        public SalesApplication(ISalesDomain catDomain, IMapper mapper)
        {
            _Domain = catDomain;
            _mapper = mapper;
        }

        public async Task<Response<string>> InsertAsync(SaleDTO modelDto)
        {
            var response = new Response<string>();
            try
            {
                var resp = _mapper.Map<Sale>(modelDto);
                response.Data = await _Domain.InsertAsync(resp);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = response.Data;
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

        public async Task<Response<string>> UpdateAsync(SaleDTO modelDto)
        {
            var response = new Response<string>();
            try
            {
                var resp = _mapper.Map<Sale>(modelDto);
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
                if (response.Data == "Success")
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

        public async Task<Response<SaleDTO>> GetAsync(int ID)
        {
            var response = new Response<SaleDTO>();
            try
            {
                var result = await _Domain.GetAsync(ID);

                response.Data = _mapper.Map<SaleDTO>(result);
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

        public async Task<Response<IEnumerable<SaleDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<SaleDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<SaleDTO>>(resp);
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
