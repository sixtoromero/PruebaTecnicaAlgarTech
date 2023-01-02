using System;
using System.Collections.Generic;
using System.Text;

namespace algart.Application.DTO
{
    public class SaleDetailDTO
    {
        public int Id { get; set; }
        public int? SaleId { get; set; }
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
