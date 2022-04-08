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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Delete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public async Task<Category> Get(Expression<Func<Category, bool>> filter)
        {
            return await _categoryDal.Get(filter);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _categoryDal.GetAll();
        }

        public async Task<List<Category>> GetAll(Expression<Func<Category, bool>> filter)
        {
            return await _categoryDal.GetAll(filter);
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _categoryDal.GetById(id);
        }

        public void Insert(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void Update(Category t)
        {
            _categoryDal.Update(t);

        }
    }
}
