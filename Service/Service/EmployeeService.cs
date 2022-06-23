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
    public class EmployeeService : BaseService<Employee>
    {
        private readonly IMongoRepository<Employee> repository;

        public EmployeeService(IMongoRepository<Employee> repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<ListDataResponse<Employee>> GetEmployee(EmployeePager pager)
        {
            var response = new ListDataResponse<Employee>();
            try
            {
                var filters = new List<FilterParams>();
                if (pager.Status > 0)
                {
                    filters.Add(new FilterParams() { Prop = "Status", Value = pager.Status, Type = (int)FilterType.EQUAL });
                }

                var resultQuery = await repository.FilterExpression(filters, pager);

                response.TotalRecord = resultQuery.TotalRecord;
                response.Data = resultQuery.Data;
                //response.Data = response.Data.Where(o => o.Status == 1).ToList();
                response.StatusCode = ResponseStatusCode.Success;
            }
            catch(Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.ErrorMessage = EnumMessage.ERROR.GetDescription();
            }
            return response;
        }
    }
}
