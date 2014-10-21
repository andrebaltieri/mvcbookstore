using MvcBookStore.Service.Contracts;
using System.Web.Mvc;

namespace MvcBookStore.Web.Controllers
{
    public class BookController : Controller
    {
        private IBookService _service;

        public BookController(IBookService service)
        {
            this._service = service;
        }

        public ActionResult Index()
        {
            return View(_service.Get());
        }

        public ActionResult Create()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}