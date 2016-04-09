using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Data.Entity;
using OpenBiz.Models.Core.Repositories;

namespace OpenBiz.Models.Persistence.Repositories
{
    public class DBRepository<TEntity>:IRepository<TEntity> where TEntity : class
    {
        public static DbSet<TEntity> _entity { get; set; }

        protected SCMSContext _context { get; set; }
        protected ILogger<DBRepository<TEntity>> _logger { get; set; }



        public DBRepository(SCMSContext context,ILogger<DBRepository<TEntity>> logger)
        {
            _context = context;
            _logger = logger;
            _entity = _context.Set<TEntity>();
        }

        public static DbSet<TEntity> GetEntity()
        {
            DbSet<TEntity> entity = _entity;
            return entity;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _entity.ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError("Error while getting Entity from the Database.", ex);
                throw;
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return _entity.Where(predicate).AsNoTracking();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while finding Entity from the Database.", ex);
                throw;
            }
        }

        public void Add(TEntity entity)
        {
            try
            {
                _entity.Add(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while adding Entity to the Database.", ex);
                throw;
            }
        }

        public void Remove(TEntity entity)
        {
            try
            {
                _entity.Remove(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while finding Entity from the Database.", ex);
                throw;
            }
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        //public void Update(TEntity entity, object property)
        //{
        //        _context.Entry(property).State = EntityState.Modified;
        //}
    }
}
