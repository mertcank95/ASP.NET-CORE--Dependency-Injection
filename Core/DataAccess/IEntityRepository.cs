using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public interface IEntityRepository<T> where T : class, IEntity, new()  
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>>? filter = null);
        void FakeDataInsert(IList<T> entities);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
