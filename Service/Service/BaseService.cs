using Microsoft.AspNetCore.Http;
using Service.Entities;
using Service.Models;
using Service.Models.ReponseModel;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class BaseService<T> where T : BaseEntity
    {
        private readonly IMongoRepository<T> repository;

        public BaseService(IMongoRepository<T> repository)
        {
            this.repository = repository;
        }

        public async virtual Task<ListDataResponse<T>> GetAll()
        {
            var response = new ListDataResponse<T>();
            try
            {
                var listData = await repository.GetAllAsync();
                response.TotalRecord = listData.Count();
                response.Data = listData.ToList();
                response.StatusCode = ResponseStatusCode.Success;
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.ErrorMessage = EnumMessage.ERROR.GetDescription();
            }
            return response;
        }

        public async Task<T> GetById(string id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async virtual Task<Response> Insert(T entity, HttpContext context)
        {
            var response = new Response();
            try
            {
                entity.CreatedDate = DateTime.Now;
                entity.UpdatedDate = DateTime.Now;
                entity.CreatedBy = context.Request.Headers["UserName"];
                entity.UpdatedBy = context.Request.Headers["UserName"];
                var count = await repository.InsertAsync(entity);
                response.StatusCode = ResponseStatusCode.Success;
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.ErrorMessage = EnumMessage.ERROR.GetDescription();
            }
            return response;
        }

        public async virtual Task<Response> Update(T entity, HttpContext context)
        {
            var response = new Response();
            try
            {
                var collection = await repository.GetByIdAsync(entity.Id);
                if (collection == null)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.ErrorMessage = EnumMessage.NOT_FOUND.GetDescription();
                    return response;
                }

                var currentEntity = await GetById(entity.Id);

                entity.CreatedDate = currentEntity.CreatedDate;
                entity.CreatedBy = currentEntity.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = context.Request.Headers["UserName"];
                var count = await repository.UpdateAsync(entity);
                response.StatusCode = ResponseStatusCode.Success;
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.ErrorMessage = EnumMessage.ERROR.GetDescription();
            }
            return response;
        }

        public async virtual Task<Response> Delete(string id)
        {
            var response = new Response();
            try
            {
                var collection = repository.GetById(id);
                if (collection == null)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.ErrorMessage = EnumMessage.NOT_FOUND.GetDescription();
                    return response;
                }
                await repository.DeleteAsync(id);
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
