using DataAccessLayer.Abstract;
using DataAccessLayer.Contrete.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter)
        {
            return filter == null
             ? await _context.Set<T>().ToListAsync()
             : await _context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
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
            _context.SaveChangesAsync();
        }
    }
}
