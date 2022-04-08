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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Delete(About t)
        {
            _aboutDal.Delete(t);
        }

        public async Task<About> Get(Expression<Func<About, bool>> filter)
        {
            return await _aboutDal.Get(filter);
        }

        public async Task<List<About>> GetAll()
        {
            return await _aboutDal.GetAll();
        }

        public async Task<List<About>> GetAll(Expression<Func<About, bool>> filter)
        {
            return await _aboutDal.GetAll(filter);
        }

        public async Task<About> GetById(Guid id)
        {
            return await _aboutDal.GetById(id);
        }

        public void Insert(About t)
        {
            _aboutDal.Insert(t);
        }

        public void Update(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
