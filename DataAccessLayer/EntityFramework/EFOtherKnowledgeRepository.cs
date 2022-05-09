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
    public class EFOtherKnowledgeRepository : GenericRepository<OtherKnowledge>, IOtherKnowledgeDal
    {
        public async Task<List<OtherKnowledge>> GetAllTrue(Expression<Func<OtherKnowledge, bool>> filter)
        {
            using (var context = new MyContext())
            {
                return await context.OtherKnowledges.Where(filter).OrderBy(x => x.Order).ToListAsync();
            }
        }
    }
}
