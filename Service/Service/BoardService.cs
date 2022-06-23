using Service.Entities;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class BoardService : BaseService<Board>
    {
        private readonly IMongoRepository<Board> repository;
        public BoardService(IMongoRepository<Board> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
