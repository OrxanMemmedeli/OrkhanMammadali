using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class SosialManager : ISosialService
    {
        private readonly ISosialDal _sosialDal;

        public SosialManager(ISosialDal sosialDal)
        {
            _sosialDal = sosialDal;
        }

        public void Delete(Sosial t)
        {
            _sosialDal.Delete(t);
        }

        public Sosial Get(Expression<Func<Sosial, bool>> filter)
        {
            return _sosialDal.Get(filter);
        }

        public List<Sosial> GetAll()
        {
            return _sosialDal.GetAll();
        }

        public List<Sosial> GetAll(Expression<Func<Sosial, bool>> filter)
        {
            return _sosialDal.GetAll(filter);
        }

        public Sosial GetById(int id)
        {
            return _sosialDal.GetById(id);
        }

        public void Insert(Sosial t)
        {
            _sosialDal.Insert(t);
        }

        public void Update(Sosial t)
        {
            _sosialDal.Update(t);
        }
    }
}
