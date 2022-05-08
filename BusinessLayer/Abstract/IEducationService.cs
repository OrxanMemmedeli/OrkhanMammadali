using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IEducationService : IGenericService<Education>
    {
        Task<List<Education>> GetAllTrue(Expression<Func<Education, bool>> filter);
    }
}
