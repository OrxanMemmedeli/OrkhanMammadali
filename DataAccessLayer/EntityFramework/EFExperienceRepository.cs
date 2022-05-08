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
    public class EFExperienceRepository : GenericRepository<Experience>, IExperienceDal
    {
        public async Task<List<Experience>> GetAllTrue(Expression<Func<Experience, bool>> filter)
        {
            using (var context = new MyContext())
            {
                return await context.Experiences.Where(filter).OrderBy(x => x.Order).ToListAsync();
            }
        }
    }
}
