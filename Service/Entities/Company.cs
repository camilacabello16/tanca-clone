using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Website { get; set; }
        public string Provide { get; set; }
        public string District { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string? FoundingDate { get; set; }
        public string? BankName { get; set; }
        public string? BankNumber { get; set; }
        public string? TaxNumber { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
    }
}
