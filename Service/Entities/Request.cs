using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities
{
    public class Request : BaseEntity
    {
        public string EmployeeId { get; set; }
        public string Type { get; set; }
        public string? Title { get; set; }
        public string? Amount { get; set; }
        public string? Reason { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Address { get; set; }
        public string? WorkShiftId { get; set; }
        public int? LeaveType { get; set; }
        public DateTime? LeaveDateStart { get; set; }
        public DateTime? LeaveDateEnd { get; set; }
        public int Status { get; set; }
    }
}
