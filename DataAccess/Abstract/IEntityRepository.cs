using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Abstract;

namespace DataAccess.Abstract
{
    // Generic constrain
    // class : referanstip olabilir.
    // IEntity olabilir veya IEntity impilemente eden olabilir
    public interface IEntityRepository<T> where T : class, IEntity, new()

    {
    List<T> GetAll(Expression<Func<T, bool>> filter = null);
    T Get(Expression<Func<T, bool>> filter);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);

    }
}
