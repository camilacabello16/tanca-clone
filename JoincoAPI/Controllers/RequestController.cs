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
    public class RequestController : ControllerBase
    {
        private readonly RequestService service;

        public RequestController(RequestService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ListDataResponse<Request>> GetRequest(RequestPager pager)
        {
            return await service.GetRequest(pager);
        }
        [HttpGet]
        public async Task<ListDataResponse<Request>> GetAll()
        {
            return await service.GetAll();
        }
        [HttpPost]
        public async Task<Response> Insert(Request input)
        {
            return await service.Insert(input, HttpContext);
        }
        [HttpPost]
        public async Task<Response> Update(Request input)
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
