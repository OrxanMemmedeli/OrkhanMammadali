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

        public async Task<Education>  Get(Expression<Func<Education, bool>> filter)
        {
            return await  _educationDal.Get(filter);
        }

        public async Task<List<Education>>  GetAll()
        {
            return await  _educationDal.GetAll();
        }

        public async Task<List<Education>>  GetAll(Expression<Func<Education, bool>> filter)
        {
            return await  _educationDal.GetAll(filter);
        }

        public async Task<List<Education>> GetAllTrue(Expression<Func<Education, bool>> filter)
        {
            return await _educationDal.GetAllTrue(filter);
        }

        public async Task<Education>  GetById(Guid id)
        {
            return await  _educationDal.GetById(id);
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
