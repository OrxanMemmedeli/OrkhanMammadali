using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

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

        public About Get(Expression<Func<About, bool>> filter)
        {
            return _aboutDal.Get(filter);
        }

        public List<About> GetAll()
        {
            return _aboutDal.GetAll();
        }

        public List<About> GetAll(Expression<Func<About, bool>> filter)
        {
            return _aboutDal.GetAll(filter);
        }

        public About GetById(int id)
        {
            return _aboutDal.GetById(id);
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
