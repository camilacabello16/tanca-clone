using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models.ReponseModel
{
    public class Response
    {
        public ResponseStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Id { get; set; }
    }

    public class ListDataResponse<T> : Response
    {
        public List<T> Data { get; set; }
        public int TotalRecord { get; set; }
    }
}
