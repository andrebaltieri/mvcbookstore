using AutoMapper;
using MvcBookStore.Domain;
using MvcBookStore.Domain.Repositories;
using MvcBookStore.Web.Models.Book;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            try
            {
                var result = Mapper.Map<List<Book>, List<DisplayBookShortInfoViewModel>>(_repository.Get().ToList());
                return View(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DefaultErrorMessage", "Falha ao recuperar os livros. <br />Detalhes do erro: " + ex.Message);
                return View(new List<DisplayBookShortInfoViewModel>());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateBookViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (Request.Files.Count == 0)
            {
                ModelState.AddModelError("DefaultErrorMessage", "Imagem inválida");
                return View(model);
            }

            var file = Request.Files[0];
            if (file == null || file.ContentLength <= 0)
            {
                ModelState.AddModelError("DefaultErrorMessage", "Imagem inválida");
                return View(model);
            }

            try
            {
                string bookFile = "";
                var extension = Path.GetExtension(file.FileName);
                var name = Guid.NewGuid().ToString() + extension;
                bookFile = "content/img/books/" + name;
                file.SaveAs(Path.Combine(Server.MapPath("~/content/img/books/"), name));

                var book = new Book(model.Title, model.ReleaseDate, model.ISBN, bookFile);
                _repository.SaveOrUpdate(book);
                return RedirectToAction("Edit", new { id = book.Id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DefaultErrorMessage", "Falha ao salvar livro. <br />Detalhes do erro: " + ex.Message);
                return View(model);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
        }
    }
}