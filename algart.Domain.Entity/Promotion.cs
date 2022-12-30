﻿using System;
using System.Collections.Generic;
using System.Text;

namespace algart.Domain.Entity
{
    public class Promotion
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? Percentage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
