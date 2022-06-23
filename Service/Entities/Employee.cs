using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities
{
    public class Employee : BaseEntity
    {
        public string EmployeeCode { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Skype { get; set; }
        public string? Facebook { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Provide { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public int Status { get; set; }
        public string RoleId { get; set; }
        public string BranchId { get; set; }
        public string TitleId { get; set; }
        public string DepartmentId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime OfficialDate { get; set; }
        public string Qualification { get; set; }
        public string Major { get; set; }
    }
}
