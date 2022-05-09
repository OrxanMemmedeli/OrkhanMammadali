using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProjectService : IGenericService<Project>
    {
        Task<List<Project>> GetAllWithCategory(Expression<Func<Project, bool>> filter);
        Task<List<Project>> GetAllWithCategory();
    }
}
