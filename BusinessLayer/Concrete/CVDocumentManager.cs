using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class CVDocumentManager : ICVDocumentService
    {
        private readonly ICVDocumentDal _cvDocumentDal;

        public CVDocumentManager(ICVDocumentDal cvDocumentDal)
        {
            _cvDocumentDal = cvDocumentDal;
        }

        public void Delete(CVDocument t)
        {
            _cvDocumentDal.Delete(t);
        }

        public CVDocument Get(Expression<Func<CVDocument, bool>> filter)
        {
            return _cvDocumentDal.Get(filter);
        }

        public List<CVDocument> GetAll()
        {
            return _cvDocumentDal.GetAll();
        }

        public List<CVDocument> GetAll(Expression<Func<CVDocument, bool>> filter)
        {
            return _cvDocumentDal.GetAll(filter);
        }

        public CVDocument GetById(int id)
        {
            return _cvDocumentDal.GetById(id);
        }

        public void Insert(CVDocument t)
        {
            _cvDocumentDal.Insert(t);
        }

        public void Update(CVDocument t)
        {
            _cvDocumentDal.Update(t);
        }
    }
}
