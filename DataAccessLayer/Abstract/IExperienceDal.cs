using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IExperienceDal : IGenericDal<Experience>
    {
        Task<List<Experience>> GetAllTrue(Expression<Func<Experience, bool>> filter);
    }
}
