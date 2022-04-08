using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class OtherKnowledgeManager : IOtherKnowledgeService
    {
        private readonly IOtherKnowledgeDal _otherKnowledgeDal;

        public OtherKnowledgeManager(IOtherKnowledgeDal otherKnowledgeDal)
        {
            _otherKnowledgeDal = otherKnowledgeDal;
        }

        public void Delete(OtherKnowledge t)
        {
            _otherKnowledgeDal.Delete(t);
        }

        public OtherKnowledge Get(Expression<Func<OtherKnowledge, bool>> filter)
        {
            return _otherKnowledgeDal.Get(filter);
        }

        public List<OtherKnowledge> GetAll()
        {
            return _otherKnowledgeDal.GetAll();
        }

        public List<OtherKnowledge> GetAll(Expression<Func<OtherKnowledge, bool>> filter)
        {
            return _otherKnowledgeDal.GetAll(filter);
        }

        public OtherKnowledge GetById(int id)
        {
            return _otherKnowledgeDal.GetById(id);
        }

        public void Insert(OtherKnowledge t)
        {
            _otherKnowledgeDal.Insert(t);
        }

        public void Update(OtherKnowledge t)
        {
            _otherKnowledgeDal.Update(t);
        }
    }
}
