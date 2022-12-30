using System;
using System.Collections.Generic;
using System.Text;

namespace algart.Domain.Entity
{
    public class SalebyDetail
    {
        public Sale Sales { get; set; }
        public SaleDetail SaleDetails { get; set; }
    }
}
