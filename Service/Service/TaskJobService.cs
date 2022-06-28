using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Entities;
using Service.Models.ReponseModel;
using Service.Models.RequestModel;
using Service.Models;

namespace Service.Service
{
    public class TaskJobService : BaseService<TaskJob>
    {
        private readonly IMongoRepository<TaskJob> repository;

        public TaskJobService(IMongoRepository<TaskJob> repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<ListDataResponse<TaskJob>> GetTask(TaskPager pager)
        {
            var response = new ListDataResponse<TaskJob>();
            try
            {
                var filters = new List<FilterParams>();
                if (!string.IsNullOrEmpty(pager.BoardId))
                {
                    filters.Add(new FilterParams() { Prop = "BoardId", Value = pager.BoardId, Type = (int)FilterType.EQUAL });
                }
                if (pager.Status > 0)
                {
                    filters.Add(new FilterParams() { Prop = "Status", Value = pager.Status, Type = (int)FilterType.EQUAL });
                }
                if (!string.IsNullOrEmpty(pager.Assign))
                {
                    filters.Add(new FilterParams() { Prop = "Assign", Value = pager.Assign, Type = (int)FilterType.EQUAL });
                }

                var resultQuery = await repository.FilterExpression(filters, pager);

                response.TotalRecord = resultQuery.TotalRecord;
                response.Data = resultQuery.Data;
                //response.Data = response.Data.Where(o => o.Status == 1).ToList();
                response.StatusCode = ResponseStatusCode.Success;
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.ErrorMessage = EnumMessage.ERROR.GetDescription();
            }
            return response;
        }
    }
}
