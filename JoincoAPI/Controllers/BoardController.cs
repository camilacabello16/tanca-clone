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
    public class BoardController : ControllerBase
    {
        private readonly BoardService service;

        public BoardController(BoardService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ListDataResponse<Board>> GetBoard(BoardPager pager)
        {
            return await service.GetBoard(pager);
        }
        [HttpGet]
        public async Task<ListDataResponse<Board>> GetAll()
        {
            return await service.GetAll();
        }
        [HttpPost]
        public async Task<Response> Insert(Board input)
        {
            return await service.Insert(input, HttpContext);
        }
        [HttpPost]
        public async Task<Response> Update(Board input)
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
