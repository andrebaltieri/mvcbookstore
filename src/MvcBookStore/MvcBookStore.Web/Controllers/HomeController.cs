using MvcBookStore.Domain.Repositories;
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
            return View(_repository.GetTopSales());
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
        }
	}
}