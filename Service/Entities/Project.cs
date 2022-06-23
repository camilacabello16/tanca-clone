using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string? BranchId { get; set; }
        public string? DepartmentId { get; set; }
        public string? TitleId { get; set; }
    }
}
