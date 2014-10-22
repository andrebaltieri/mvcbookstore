using MvcBookStore.Domain.Repositories;
using System.Web.Mvc;

namespace MvcBookStore.Web.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult Index()
        {
            return View(_repository.Get());
        }

        public ActionResult Create()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
        }
    }
}