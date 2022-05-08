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

        public async Task<Experience> Get(Expression<Func<Experience, bool>> filter)
        {
            return await _experienceDal.Get(filter);
        }

        public async Task<List<Experience>> GetAll()
        {
            return await _experienceDal.GetAll();
        }

        public async Task<List<Experience>> GetAll(Expression<Func<Experience, bool>> filter)
        {
            return await _experienceDal.GetAll(filter);
        }

        public async Task<List<Experience>> GetAllTrue(Expression<Func<Experience, bool>> filter)
        {
            return await _experienceDal.GetAllTrue(filter);
        }

        public async Task<Experience> GetById(Guid id)
        {
            return await _experienceDal.GetById(id);
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
