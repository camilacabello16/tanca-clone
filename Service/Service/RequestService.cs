using Service.Entities;
using Service.Models;
using Service.Models.ReponseModel;
using Service.Models.RequestModel;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class RequestService : BaseService<Request>
    {
        private readonly IMongoRepository<Request> repository;

        public RequestService(IMongoRepository<Request> repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<ListDataResponse<Request>> GetRequest(RequestPager pager)
        {
            var response = new ListDataResponse<Request>();
            try
            {
                var filters = new List<FilterParams>();
                if (pager.Status > 0)
                {
                    filters.Add(new FilterParams() { Prop = "Status", Value = pager.Status, Type = (int)FilterType.EQUAL });
                }
                if (pager.Type > 0)
                {
                    filters.Add(new FilterParams() { Prop = "Type", Value = pager.Type, Type = (int)FilterType.EQUAL });
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
