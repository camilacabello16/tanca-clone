using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models.ReponseModel
{
    public class FilterResponse<TEntity>
    {
        public List<TEntity> Data { get; set; }
        public int TotalRecord { get; set; }

    }
}
