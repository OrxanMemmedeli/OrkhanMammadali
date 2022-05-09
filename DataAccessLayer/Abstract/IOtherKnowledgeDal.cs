using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IOtherKnowledgeDal : IGenericDal<OtherKnowledge>
    {
        Task<List<OtherKnowledge>> GetAllTrue(Expression<Func<OtherKnowledge, bool>> filter);
    }
}
