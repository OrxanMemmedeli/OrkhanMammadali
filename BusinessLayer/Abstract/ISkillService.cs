using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISkillService : IGenericService<Skill>
    {
        Task<List<Skill>> GetAllTrue(Expression<Func<Skill, bool>> filter);
    }
}
