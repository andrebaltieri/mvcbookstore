using MvcBookStore.Domain.Contracts;
using MvcBookStore.Service.Contracts;
using MvcBookStore.ViewModel.Book;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcBookStore.Service
{
    public class BookService : IBookService
    {
        private IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            this._repository = repository;
        }

        public IList<DisplayBookShortInfoViewModel> Get()
        {
            return _repository.Get().Select(x => new DisplayBookShortInfoViewModel
            {
                Id = x.Id,
                Image = x.Image,
                ISBN = x.ISBN,
                QuantitySaled = x.QuantitySaled,
                ReleaseDate = x.ReleaseDate,
                Title = x.Title
            })
            .ToList();
        }

        public IList<DisplayBookShortInfoViewModel> GetTopSales()
        {
            return _repository.GetTopSales().Select(x => new DisplayBookShortInfoViewModel
            {
                Id = x.Id,
                Image = x.Image,
                ISBN = x.ISBN,
                QuantitySaled = x.QuantitySaled,
                ReleaseDate = x.ReleaseDate,
                Title = x.Title
            })
            .ToList();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
