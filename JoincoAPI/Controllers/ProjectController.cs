using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Entities;
using Service.Models.ReponseModel;
using Service.Service;

namespace Controller.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService service;

        public ProjectController(ProjectService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ListDataResponse<Project>> GetAll()
        {
            return await service.GetAll();
        }
        [HttpPost]
        public async Task<Response> Insert(Project input)
        {
            return await service.Insert(input, HttpContext);
        }
        [HttpPost]
        public async Task<Response> Update(Project input)
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
