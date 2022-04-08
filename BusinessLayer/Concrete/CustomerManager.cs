﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

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

        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            return _customerDal.Get(filter);
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter)
        {
            return _customerDal.GetAll(filter);
        }

        public Customer GetById(int id)
        {
            return _customerDal.GetById(id);
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
