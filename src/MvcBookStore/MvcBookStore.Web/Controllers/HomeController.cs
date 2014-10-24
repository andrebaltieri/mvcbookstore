using AutoMapper;
using MvcBookStore.Domain;
using MvcBookStore.Domain.Repositories;
using MvcBookStore.Web.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcBookStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repository;

        public HomeController(IBookRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult Index()
        {
            try
            {
                var result = Mapper.Map<List<Book>, List<DisplayBookShortInfoViewModel>>(_repository.GetTopSales().ToList());
                return View(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DefaultErrorMessage", "Falha ao recuperar os livros mais vendidos. <br />Detalhes do erro: " + ex.Message);
                return View(new List<DisplayBookShortInfoViewModel>());
            }            
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
        }
    }
}