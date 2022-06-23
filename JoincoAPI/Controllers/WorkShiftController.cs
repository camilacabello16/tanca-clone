using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Entities;
using Service.Models.ReponseModel;
using Service.Service;

namespace Controller.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkShiftController : ControllerBase
    {
        private readonly WorkShiftService service;

        public WorkShiftController(WorkShiftService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ListDataResponse<WorkShift>> GetAll()
        {
            return await service.GetAll();
        }
        [HttpPost]
        public async Task<Response> Insert(WorkShift input)
        {
            return await service.Insert(input, HttpContext);
        }
        [HttpPost]
        public async Task<Response> Update(WorkShift input)
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
