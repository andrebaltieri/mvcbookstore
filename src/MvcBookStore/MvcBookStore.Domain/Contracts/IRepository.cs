﻿using System;
using System.Collections.Generic;

namespace MvcBookStore.Domain.Contracts
{
    public interface IRepository<T> : IDisposable
    {
        IList<T> Get();
        T Get(int id);
        void SaveOrUpdate(T entity);
        void Delete(int id);
    }
}
