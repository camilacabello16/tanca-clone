using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Provide { get; set; }
        public string District { get; set; }
        public string PhoneNumber { get; set; }
        public string? Description { get; set; }
    }
}
