using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

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

        public Profil Get(Expression<Func<Profil, bool>> filter)
        {
            return _profilDal.Get(filter);
        }

        public List<Profil> GetAll()
        {
            return _profilDal.GetAll();
        }

        public List<Profil> GetAll(Expression<Func<Profil, bool>> filter)
        {
            return _profilDal.GetAll(filter);
        }

        public Profil GetById(int id)
        {
            return _profilDal.GetById(id);
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
