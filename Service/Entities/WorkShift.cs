using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities
{
    public class WorkShift : BaseEntity
    {
        public string Name { get; set; }
        public string? BranchId { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public string WeekDate { get; set; }
    }
}
