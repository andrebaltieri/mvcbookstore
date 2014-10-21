using MvcBookStore.Data.DataContexts;
using MvcBookStore.Domain;
using MvcBookStore.Domain.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MvcBookStore.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private MvcBookStoreDataContext _db;

        public BookRepository(MvcBookStoreDataContext dataContext)
        {
            this._db = dataContext;
        }

        public IList<Book> GetTopSales()
        {
            return _db.Books.OrderBy(x => x.QuantitySaled).Take(10).ToList();
        }

        public IList<Book> Get()
        {
            return _db.Books.ToList();
        }

        public Book Get(int id)
        {
            return _db.Books.Find(id);
        }

        public void SaveOrUpdate(Book entity)
        {
            if (entity.Id == 0)
                _db.Books.Add(entity);
            else
                _db.Entry<Book>(entity).State = EntityState.Modified;
            
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Books.Remove(_db.Books.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
