using System;
using System.Collections.Generic;
using System.Text;

namespace algart.Application.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? SizeId { get; set; }
        public int? ColorId { get; set; }
        public int? SalesDepartmentId { get; set; }
        public decimal? Inventory { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
