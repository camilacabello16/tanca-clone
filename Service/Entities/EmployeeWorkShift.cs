using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities
{
    public class EmployeeWorkShift : BaseEntity
    {
        public string EmployeeId { get; set; }
        public string WorkShiftId { get; set; }

    }
}
