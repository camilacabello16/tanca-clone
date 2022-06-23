using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Entities;
using Service.Models.ReponseModel;
using Service.Models.RequestModel;
using Service.Service;

namespace Controller.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService service;

        public EmployeeController(EmployeeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ListDataResponse<Employee>> GetEmployee(EmployeePager pager)
        {
            return await service.GetEmployee(pager);
        }

        [HttpPost]
        public async Task<Response> Insert(Employee employee)
        {
            return await service.Insert(employee, HttpContext);
        }
        [HttpPost]
        public async Task<Response> Update(Employee employee)
        {
            return await service.Update(employee, HttpContext);
        }
        [HttpGet("{id}")]
        public async Task<Response> Delete(string id)
        {
            return await service.Delete(id);
        }
    }
}
