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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Delete(Customer t)
        {
            _customerDal.Delete(t);
        }

        public async Task<Customer> Get(Expression<Func<Customer, bool>> filter)
        {
            return await _customerDal.Get(filter);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _customerDal.GetAll();
        }

        public async Task<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter)
        {
            return await _customerDal.GetAll(filter);
        }

        public async Task<Customer> GetById(Guid id)
        {
            return await _customerDal.GetById(id);
        }

        public void Insert(Customer t)
        {
            _customerDal.Insert(t);
        }

        public void Update(Customer t)
        {
            _customerDal.Update(t);
        }
    }
}
