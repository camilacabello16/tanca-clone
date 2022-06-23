using Service.Entities;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ProjectService : BaseService<Project>
    {
        private readonly IMongoRepository<Project> repository;
        public ProjectService(IMongoRepository<Project> repository) : base(repository)
        {
            this.repository = repository;
        }

    }
}
