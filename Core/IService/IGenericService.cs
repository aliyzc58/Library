using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.IService
{
    public interface IGenericService<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        List<T> GetBy(Expression<Func<T, bool>> expression);
        T Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(List<T> entities);
        void AddRange(List<T> entities);
        void UpdateRange(List<T> entities);
        bool Any(Expression<Func<T, bool>> expression);
        int Count(Expression<Func<T, bool>> expression);
    }
}
