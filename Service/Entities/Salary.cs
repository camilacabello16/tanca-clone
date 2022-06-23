using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities
{
    public class Salary : BaseEntity
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public string Amount { get; set; }
    }
}
