using System.Collections.Generic;

namespace MvcBookStore.Domain.Contracts
{
    public interface IBookRepository : IRepository<Book>
    {
        IList<Book> GetTopSales();
    }
}
