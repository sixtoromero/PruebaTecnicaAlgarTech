using System;
using System.Collections.Generic;
using System.Text;

namespace algart.Domain.Entity
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? CustomerId { get; set; }
        public string? FullName { get; set; }
        public decimal? Total { get; set; }
        public string? Description { get; set; }
        public bool IsSeparatePlan { get; set; }
        public int PlanSeparateId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }

        public IEnumerable<SaleDetail> SaleDetails { get; set; }
    }
}
