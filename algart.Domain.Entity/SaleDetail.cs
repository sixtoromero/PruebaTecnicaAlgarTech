using System;
using System.Collections.Generic;
using System.Text;

namespace algart.Domain.Entity
{
    public class SaleDetail
    {
        public int Id { get; set; }
        public int? SaleId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
