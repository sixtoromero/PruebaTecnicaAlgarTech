using System;
using System.Collections.Generic;
using System.Text;

namespace algart.Application.DTO
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? CustomerId { get; set; }
        public string? FullName { get; set; }
        public decimal? Total { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public IEnumerable<SaleDetailDTO> SaleDetails { get; set; }
    }
}
