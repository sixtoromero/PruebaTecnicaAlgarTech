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
    public class PlanSeparateApplication : IPlanSeparateApplication
    {
        private readonly IPlanSeparateDomain _Domain;
        private readonly IMapper _mapper;

        public PlanSeparateApplication(IPlanSeparateDomain Domain, IMapper mapper)
        {
            _Domain = Domain;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<PlanSeparateDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<PlanSeparateDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<PlanSeparateDTO>>(resp);
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
