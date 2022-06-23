using MongoDB.Driver;
using Service.Entities;
using Service.Models.ReponseModel;
using Service.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public interface IMongoRepository<TEntity> where TEntity : BaseEntity
    {
        IMongoCollection<TEntity> Collection { get; }

        //Task<FilterResponse<TEntity>> FilterBy(
        //Expression<Func<TEntity, bool>> filterExpression, Pager param);
        Task<FilterResponse<TEntity>> FilterExpression(List<FilterParams> filters, Pager param);
        TEntity GetById(string id);
        Task<TEntity> GetByIdAsync(string id);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> predicate);
        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        void InsertMany(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> InsertManyAsync(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        void UpdateMany(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entities);
        //Task Delete(TEntity entity);
        System.Threading.Tasks.Task DeleteAsync(string id);
        //void DeleteMany(IEnumerable<TEntity> entities);
        //Task<IEnumerable<TEntity>> DeleteManyAsync(IEnumerable<TEntity> entities);

    }
}
