using MvcBookStore.Data.DataContexts;
using MvcBookStore.Domain;
using MvcBookStore.Domain.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MvcBookStore.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private MvcBookStoreDataContext _db;

        public AuthorRepository(MvcBookStoreDataContext dataContext)
        {
            this._db = dataContext;
        }

        public IList<Author> Get()
        {
            return _db.Authors.ToList();
        }

        public Author Get(int id)
        {
            return _db.Authors.Find(id);
        }

        public void SaveOrUpdate(Author entity)
        {
            if (entity.Id == 0)
                _db.Authors.Add(entity);
            else
                _db.Entry<Author>(entity).State = EntityState.Modified;

            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Authors.Remove(_db.Authors.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
