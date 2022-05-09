using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ISkillDal : IGenericDal<Skill>
    {
        Task<List<Skill>> GetAllTrue(Expression<Func<Skill, bool>> filter);
    }
}
