using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities
{
    public class Board : BaseEntity
    {
        public string Name { get; set; }
        public string ProjectId { get; set; }
    }
}
