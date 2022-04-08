using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

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

        public Project Get(Expression<Func<Project, bool>> filter)
        {
            return _projectDal.Get(filter);
        }

        public List<Project> GetAll()
        {
            return _projectDal.GetAll();
        }

        public List<Project> GetAll(Expression<Func<Project, bool>> filter)
        {
            return _projectDal.GetAll(filter);
        }

        public Project GetById(int id)
        {
            return _projectDal.GetById(id);
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
