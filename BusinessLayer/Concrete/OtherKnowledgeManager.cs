using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<OtherKnowledge> Get(Expression<Func<OtherKnowledge, bool>> filter)
        {
            return await _otherKnowledgeDal.Get(filter);
        }

        public async Task<List<OtherKnowledge>> GetAll()
        {
            return await _otherKnowledgeDal.GetAll();
        }

        public async Task<List<OtherKnowledge>> GetAll(Expression<Func<OtherKnowledge, bool>> filter)
        {
            return await _otherKnowledgeDal.GetAll(filter);
        }

        public async Task<List<OtherKnowledge>> GetAllTrue(Expression<Func<OtherKnowledge, bool>> filter)
        {
            return await _otherKnowledgeDal.GetAllTrue(filter);
        }

        public async Task<OtherKnowledge> GetById(Guid id)
        {
            return await _otherKnowledgeDal.GetById(id);
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
