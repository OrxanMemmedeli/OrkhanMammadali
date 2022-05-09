using DataAccessLayer.Abstract;
using DataAccessLayer.Contrete.Context;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFSkillRepository : GenericRepository<Skill>, ISkillDal
    {
        public async Task<List<Skill>> GetAllTrue(Expression<Func<Skill, bool>> filter)
        {
            using (var context = new MyContext())
            {
                return await context.Skills.Where(filter).OrderBy(x => x.Order).ToListAsync();
            }
        }
    }
}
