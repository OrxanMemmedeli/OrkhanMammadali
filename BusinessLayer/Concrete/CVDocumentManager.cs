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

        public async Task<CVDocument> Get(Expression<Func<CVDocument, bool>> filter)
        {
            return await _cvDocumentDal.Get(filter);
        }

        public async Task<List<CVDocument>> GetAll()
        {
            return await _cvDocumentDal.GetAll();
        }

        public async Task<List<CVDocument>> GetAll(Expression<Func<CVDocument, bool>> filter)
        {
            return await _cvDocumentDal.GetAll(filter);
        }

        public async Task<CVDocument> GetById(Guid id)
        {
            return await _cvDocumentDal.GetById(id);
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
