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

        public async Task<Sosial> Get(Expression<Func<Sosial, bool>> filter)
        {
            return await _sosialDal.Get(filter);
        }

        public async Task<List<Sosial>> GetAll()
        {
            return await _sosialDal.GetAll();
        }

        public async Task<List<Sosial>> GetAll(Expression<Func<Sosial, bool>> filter)
        {
            return await _sosialDal.GetAll(filter);
        }

        public async Task<Sosial> GetById(Guid id)
        {
            return await _sosialDal.GetById(id);
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
