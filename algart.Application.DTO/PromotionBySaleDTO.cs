using System;
using System.Collections.Generic;
using System.Text;

namespace algart.Application.DTO
{
    public class PromotionBySaleDTO
    {
        public int Id { get; set; }
        public int? PromotionId { get; set; }
        public int? SaleId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
