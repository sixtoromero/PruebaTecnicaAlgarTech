using System;
using System.Collections.Generic;
using System.Text;

namespace algart.Application.DTO
{
    public class ColorDTO
    {
        public int Id { get; set; }
        public string? Color1 { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
