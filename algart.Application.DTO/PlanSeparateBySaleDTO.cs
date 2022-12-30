using System;
using System.Collections.Generic;
using System.Text;

namespace algart.Application.DTO
{
    public class PlanSeparateBySaleDTO
    {
        public int Id { get; set; }
        public int? PlanSeparateId { get; set; }
        public int? SaleId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }        
    }
}
