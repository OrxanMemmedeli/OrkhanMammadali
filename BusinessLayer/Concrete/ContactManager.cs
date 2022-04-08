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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Delete(Contact t)
        {
            _contactDal.Delete(t);
        }

        public async Task<Contact> Get(Expression<Func<Contact, bool>> filter)
        {
            return await _contactDal.Get(filter);
        }

        public async Task<List<Contact>> GetAll()
        {
            return await _contactDal.GetAll();
        }

        public async Task<List<Contact>> GetAll(Expression<Func<Contact, bool>> filter)
        {
            return await _contactDal.GetAll(filter);
        }

        public async Task<Contact> GetById(Guid id)
        {
            return await _contactDal.GetById(id);
        }

        public void Insert(Contact t)
        {
            _contactDal.Insert(t);
        }

        public void Update(Contact t)
        {
            _contactDal.Update(t);
        }
    }
}
