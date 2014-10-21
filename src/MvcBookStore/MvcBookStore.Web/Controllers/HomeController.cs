using MvcBookStore.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return View(_repository.Get());
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
        }
	}
}