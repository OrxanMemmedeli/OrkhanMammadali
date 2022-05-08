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
    public class EFEducationRepository : GenericRepository<Education>, IEducationDal
    {
        public async Task<List<Education>> GetAllTrue(Expression<Func<Education, bool>> filter)
        {
            using (var context = new MyContext())
            {
                return await context.Educations.Where(filter).OrderBy(x => x.Order).ToListAsync();
            }
        }
    }
}
