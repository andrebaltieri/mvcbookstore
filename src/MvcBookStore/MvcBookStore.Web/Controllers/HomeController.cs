using MvcBookStore.Service.Contracts;
using System.Web.Mvc;

namespace MvcBookStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private IBookService _service;

        public HomeController(IBookService service)
        {
            this._service = service;
        }

        public ActionResult Index()
        {
            return View(_service.GetTopSales());
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
	}
}