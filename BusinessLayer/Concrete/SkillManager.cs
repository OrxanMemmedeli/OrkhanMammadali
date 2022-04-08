using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

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

        public Skill Get(Expression<Func<Skill, bool>> filter)
        {
            return _skillDal.Get(filter);
        }

        public List<Skill> GetAll()
        {
            return _skillDal.GetAll();
        }

        public List<Skill> GetAll(Expression<Func<Skill, bool>> filter)
        {
            return _skillDal.GetAll(filter);
        }

        public Skill GetById(int id)
        {
            return _skillDal.GetById(id);
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
