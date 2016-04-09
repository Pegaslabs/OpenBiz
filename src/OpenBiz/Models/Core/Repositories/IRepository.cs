using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OpenBiz.Models.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        bool SaveAll();
    }
}