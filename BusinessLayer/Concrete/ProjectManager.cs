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
    public class ProjectManager : IProjectService
    {
        private readonly IProjectDal _projectDal;

        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }

        public void Delete(Project t)
        {
            _projectDal.Delete(t);
        }

        public async Task<Project> Get(Expression<Func<Project, bool>> filter)
        {
            return await  _projectDal.Get(filter);
        }

        public async Task<List<Project>> GetAll()
        {
            return await  _projectDal.GetAll();
        }

        public async Task<List<Project>> GetAll(Expression<Func<Project, bool>> filter)
        {
            return await  _projectDal.GetAll(filter);
        }

        public async Task<Project> GetById(Guid id)
        {
            return await  _projectDal.GetById(id);
        }

        public void Insert(Project t)
        {
            _projectDal.Insert(t);
        }

        public void Update(Project t)
        {
            _projectDal.Update(t);
        }
    }
}
