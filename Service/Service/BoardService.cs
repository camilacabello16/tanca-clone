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
    public class BoardService : BaseService<Board>
    {
        private readonly IMongoRepository<Board> repository;
        public BoardService(IMongoRepository<Board> repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<ListDataResponse<Board>> GetBoard(BoardPager pager)
        {
            var response = new ListDataResponse<Board>();
            try
            {
                var filters = new List<FilterParams>();
                if (!string.IsNullOrEmpty(pager.ProjectId))
                {
                    filters.Add(new FilterParams() { Prop = "ProjectId", Value = pager.ProjectId, Type = (int)FilterType.EQUAL });
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
