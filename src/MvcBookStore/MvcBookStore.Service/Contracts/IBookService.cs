using MvcBookStore.Domain;
using MvcBookStore.ViewModel.Book;
using System;
using System.Collections.Generic;

namespace MvcBookStore.Service.Contracts
{
    public interface IBookService : IDisposable
    {
        IList<DisplayBookShortInfoViewModel> GetTopSales();
        IList<DisplayBookShortInfoViewModel> Get();
    }
}
