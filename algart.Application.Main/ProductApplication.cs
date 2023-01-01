using algart.Application.DTO;
using algart.Application.Interface;
using algart.Domain.Interface;
using algart.Transversal.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace algart.Application.Main
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductDomain _Domain;
        private readonly IMapper _mapper;

        public ProductApplication(IProductDomain Domain, IMapper mapper)
        {
            _Domain = Domain;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ProductDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<ProductDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<ProductDTO>>(resp);
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

        public async Task<Response<IEnumerable<ProductDTO>>> GetProductsBySaleDepartmentIdAsync(int SalesDepartmentId)
        {
            var response = new Response<IEnumerable<ProductDTO>>();
            try
            {
                var resp = await _Domain.GetProductsBySaleDepartmentIdAsync(SalesDepartmentId);

                response.Data = _mapper.Map<IEnumerable<ProductDTO>>(resp);
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
