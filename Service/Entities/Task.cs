using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public string? Assign { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
        public int Index { get; set; }
        public string BoardId { get; set; }
    }
}
