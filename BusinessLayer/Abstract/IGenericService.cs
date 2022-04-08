using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter);
    }
}
