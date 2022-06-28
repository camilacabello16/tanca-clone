using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models.RequestModel
{
    public class Pager
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        [DefaultValue("Id")]
        public string? SortBy { get; set; }
        [DefaultValue("desc")]
        public string? OrderBy { get; set; }
    }

    public class EmployeePager : Pager
    {
        public int? Status { get; set; }
    }

    public class RequestPager : Pager
    {
        public int? Type { get; set; }
        public int? Status { set; get; }
    }

    public class BoardPager : Pager
    {
        public string? ProjectId { get; set; }
    }

    public class TaskPager : Pager
    {
        public string? BoardId { get; set; }
        public string? Assign { get; set; }
        public int? Status { get; set; }
    }
}
