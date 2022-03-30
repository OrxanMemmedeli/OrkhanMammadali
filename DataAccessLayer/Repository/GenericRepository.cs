using DataAccessLayer.Abstract;
using DataAccessLayer.Contrete.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly MyContext _context = new MyContext();



        public void Delete(T t)
        {
            _context.Remove(t);
            Save();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().FirstOrDefault(filter);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return filter == null
             ? _context.Set<T>().ToList()
             : _context.Set<T>().Where(filter).ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T t)
        {
            _context.Add(t);
            Save();
        }

        public void Update(T t)
        {
            _context.Update(t);
            Save();
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
