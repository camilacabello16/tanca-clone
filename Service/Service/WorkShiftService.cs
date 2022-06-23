using Service.Entities;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class WorkShiftService : BaseService<WorkShift>
    {
        private readonly IMongoRepository<WorkShift> repository;

        public WorkShiftService(IMongoRepository<WorkShift> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
