using System.Collections.Generic;

namespace MvcBookStore.Domain.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        IList<Book> GetTopSales();
    }
}
