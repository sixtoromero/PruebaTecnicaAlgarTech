using System;
using System.Collections.Generic;
using System.Text;

namespace algart.Application.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string? Identification { get; set; }
        public string? Names { get; set; }
        public string? Surnames { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? CellPhone { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
