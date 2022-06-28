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
    public class TaskJobController : ControllerBase
    {
        private readonly TaskJobService service;

        public TaskJobController(TaskJobService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ListDataResponse<TaskJob>> GetTask(TaskPager pager)
        {
            return await service.GetTask(pager);
        }
        [HttpGet]
        public async Task<ListDataResponse<TaskJob>> GetAll()
        {
            return await service.GetAll();
        }
        [HttpPost]
        public async Task<Response> Insert(TaskJob input)
        {
            return await service.Insert(input, HttpContext);
        }
        [HttpPost]
        public async Task<Response> Update(TaskJob input)
        {
            return await service.Update(input, HttpContext);
        }
        [HttpGet("{id}")]
        public async Task<Response> Delete(string id)
        {
            return await service.Delete(id);
        }
    }
}
