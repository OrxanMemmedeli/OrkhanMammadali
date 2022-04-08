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
    public class AdressManager : IAdressService
    {
        private readonly IAdeessDal _adeessDal;

        public AdressManager(IAdeessDal adeessDal)
        {
            _adeessDal = adeessDal;
        }

        public void Delete(Adress t)
        {
            _adeessDal.Delete(t);
        }

        public Task<Adress> Get(Expression<Func<Adress, bool>> filter)
        {
            return _adeessDal.Get(filter);
        }

        public Task<List<Adress>> GetAll()
        {
            return _adeessDal.GetAll();
        }

        public Task<List<Adress>> GetAll(Expression<Func<Adress, bool>> filter)
        {
            return _adeessDal.GetAll(filter);
        }

        public Task<Adress> GetById(Guid id)
        {
            return _adeessDal.GetById(id);
        }

        public void Insert(Adress t)
        {
            _adeessDal.Insert(t);
        }

        public void Update(Adress t)
        {
            _adeessDal.Update(t);
        }
    }
}
