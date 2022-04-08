using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class EducationManager : IEducationService
    {
        private readonly IEducationDal _educationDal;

        public EducationManager(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }

        public void Delete(Education t)
        {
            _educationDal.Delete(t);
        }

        public Education Get(Expression<Func<Education, bool>> filter)
        {
            return _educationDal.Get(filter);
        }

        public List<Education> GetAll()
        {
            return _educationDal.GetAll();
        }

        public List<Education> GetAll(Expression<Func<Education, bool>> filter)
        {
            return _educationDal.GetAll(filter);
        }

        public Education GetById(int id)
        {
            return _educationDal.GetById(id);
        }

        public void Insert(Education t)
        {
            _educationDal.Insert(t);
        }

        public void Update(Education t)
        {
            _educationDal.Update(t);
        }
    }
}
