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
    public class SalesDepartmentApplication : ISalesDepartmentApplication
    {
        private readonly ISalesDepartmentDomain _Domain;
        private readonly IMapper _mapper;

        public SalesDepartmentApplication(ISalesDepartmentDomain Domain, IMapper mapper)
        {
            _Domain = Domain;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<SalesDepartmentDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<SalesDepartmentDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<SalesDepartmentDTO>>(resp);
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
