using algart.Application.DTO;
using algart.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace algart.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Sale, SaleDTO>().ReverseMap();
            CreateMap<SaleDetail, SaleDetailDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<SalesDepartment, SalesDepartmentDTO>().ReverseMap();
            CreateMap<PlanSeparate, PlanSeparateDTO>().ReverseMap();
        }
    }
}
