using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class ExperienceManager : IExperienceService
    {
        private readonly IExperienceDal _experienceDal;

        public ExperienceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public void Delete(Experience t)
        {
            _experienceDal.Delete(t);
        }

        public Experience Get(Expression<Func<Experience, bool>> filter)
        {
            return _experienceDal.Get(filter);
        }

        public List<Experience> GetAll()
        {
            return _experienceDal.GetAll();
        }

        public List<Experience> GetAll(Expression<Func<Experience, bool>> filter)
        {
            return _experienceDal.GetAll(filter);
        }

        public Experience GetById(int id)
        {
            return _experienceDal.GetById(id);
        }

        public void Insert(Experience t)
        {
            _experienceDal.Insert(t);
        }

        public void Update(Experience t)
        {
            _experienceDal.Update(t);
        }
    }
}
