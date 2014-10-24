using System.Collections.Generic;

namespace MvcBookStore.Domain.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IList<Author> Get(int[] ids);
    }
}
