using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOtherKnowledgeService : IGenericService<OtherKnowledge>
    {
        Task<List<OtherKnowledge>> GetAllTrue(Expression<Func<OtherKnowledge, bool>> filter);
    }
}
