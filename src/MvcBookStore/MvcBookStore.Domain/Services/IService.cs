using System;
using System.Collections.Generic;

namespace MvcBookStore.Domain.Services
{
    public interface IService<T> : IDisposable
    {
        IList<T> Get();
        T Get(int id);
        void SaveOrUpdate(T entity);
        void Delete(int id);
    }
}
