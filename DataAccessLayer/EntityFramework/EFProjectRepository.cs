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
    public class EFProjectRepository : GenericRepository<Project>, IProjectDal
    {
        public async Task<List<Project>> GetAllWithCategory(Expression<Func<Project, bool>> filter)
        {
            using (var context = new MyContext())
            {
                return await context.Projects.Where(filter).Include(x => x.Category).OrderBy(x => x.Order).ToListAsync();
            }
        }

        public async Task<List<Project>> GetAllWithCategory()
        {
            using (var context = new MyContext())
            {
                return await context.Projects.Include(x => x.Category).ToListAsync();
            }
        }
    }
}
