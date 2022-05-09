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
    public class SkillManager : ISkillService
    {
        private readonly ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public void Delete(Skill t)
        {
            _skillDal.Delete(t);
        }

        public async Task<Skill> Get(Expression<Func<Skill, bool>> filter)
        {
            return await _skillDal.Get(filter);
        }

        public async Task<List<Skill>> GetAll()
        {
            return await _skillDal.GetAll();
        }

        public async Task<List<Skill>> GetAll(Expression<Func<Skill, bool>> filter)
        {
            return await _skillDal.GetAll(filter);
        }

        public async Task<List<Skill>> GetAllTrue(Expression<Func<Skill, bool>> filter)
        {
            return await _skillDal.GetAllTrue(filter);
        }

        public async Task<Skill> GetById(Guid id)
        {
            return await _skillDal.GetById(id);
        }

        public void Insert(Skill t)
        {
            _skillDal.Insert(t);
        }

        public void Update(Skill t)
        {
            _skillDal.Update(t);
        }
    }
}
