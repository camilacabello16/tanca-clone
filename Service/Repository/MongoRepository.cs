using MongoDB.Driver;
using Service.Entities;
using Service.MongoConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : BaseEntity
    {
        protected IMongoCollection<TEntity> _collection;
        private IMongoBaseContext _context;

        public IMongoCollection<TEntity> Collection
        {
            get
            {
                return _collection;
            }
        }
        public MongoRepository(IMongoBaseContext context)
        {
            _context = context;
            _collection = context.Database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        //public virtual async Task<FilterResponse<TEntity>> FilterExpression(List<FilterParams> filters, Pager param)
        //{
        //    return _collection.Filter(filters, param);
        //}
        public virtual TEntity GetById(string id)
        {
            return _collection.Find(e => e.Id == id).FirstOrDefault();
        }

        public virtual Task<TEntity> GetByIdAsync(string id)
        {
            return _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }
        public virtual async Task<List<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.Find(predicate).ToList();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return _collection.Find(e => true).ToListAsync();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            _collection.InsertOne(entity);
            return entity;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public virtual void InsertMany(IEnumerable<TEntity> entities)
        {
            _collection.InsertMany(entities);
        }

        public virtual async Task<IEnumerable<TEntity>> InsertManyAsync(IEnumerable<TEntity> entities)
        {
            await _collection.InsertManyAsync(entities);
            return entities;
        }

        public virtual TEntity Update(TEntity entity)
        {
            _collection.ReplaceOne(x => x.Id == entity.Id, entity, new ReplaceOptions() { IsUpsert = false });
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions() { IsUpsert = false });
            return entity; ;
        }

        public virtual void UpdateMany(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Update(entity);
            }
        }

        public virtual async Task<IEnumerable<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                await UpdateAsync(entity);
            }
            return entities;
        }

        //public virtual async Task Delete(TEntity entity)
        //{
        //    await _collection.FindOneAndDeleteAsync(e => e.Id == entity.Id);
        //}

        public virtual async System.Threading.Tasks.Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(e => e.Id == id);
        }

        //public virtual void DeleteMany(IEnumerable<TEntity> entities)
        //{
        //    foreach (TEntity entity in entities)
        //    {
        //        _collection.FindOneAndDelete(e => e.Id == entity.Id);
        //    }
        //}

        //public virtual async Task<IEnumerable<TEntity>> DeleteManyAsync(IEnumerable<TEntity> entities)
        //{
        //    foreach (TEntity entity in entities)
        //    {
        //        await DeleteAsync(entity);
        //    }
        //    return entities;
        //}
    }
}
