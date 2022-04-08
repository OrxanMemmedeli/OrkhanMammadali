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
    public class ProfilManager : IProfilService
    {
        private readonly IProfilDal _profilDal;

        public ProfilManager(IProfilDal profilDal)
        {
            _profilDal = profilDal;
        }

        public void Delete(Profil t)
        {
            _profilDal.Delete(t);
        }

        public async Task<Profil> Get(Expression<Func<Profil, bool>> filter)
        {
            return await _profilDal.Get(filter);
        }

        public async Task<List<Profil>> GetAll()
        {
            return await _profilDal.GetAll();
        }

        public async Task<List<Profil>> GetAll(Expression<Func<Profil, bool>> filter)
        {
            return await _profilDal.GetAll(filter);
        }

        public async Task<Profil> GetById(Guid id)
        {
            return await _profilDal.GetById(id);
        }

        public void Insert(Profil t)
        {
            _profilDal.Insert(t);
        }

        public void Update(Profil t)
        {
            _profilDal.Update(t);
        }
    }
}
