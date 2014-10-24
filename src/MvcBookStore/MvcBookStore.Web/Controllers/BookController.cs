using AutoMapper;
using MvcBookStore.Domain;
using MvcBookStore.Domain.Repositories;
using MvcBookStore.Web.Models.Book;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace MvcBookStore.Web.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;

        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            this._bookRepository = bookRepository;
            this._authorRepository = authorRepository;
        }

        #region Index
        public ActionResult Index()
        {
            try
            {
                var result = Mapper.Map<List<Book>, List<DisplayBookShortInfoViewModel>>(_bookRepository.Get().ToList());
                return View(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DefaultErrorMessage", "Falha ao recuperar os livros. <br />Detalhes do erro: " + ex.Message);
                return View(new List<DisplayBookShortInfoViewModel>());
            }
        }
        #endregion

        #region Details
        public ActionResult Details(int id)
        {
            var book = _bookRepository.Get(id);
            if (book == null)
                return HttpNotFound();

            return View(book);
        }
        #endregion

        #region Create
        public ActionResult Create()
        {
            ViewBag.Authors = _authorRepository.Get();
            return View();
        }

        [HttpPost]
        public ActionResult Create(EditorBookViewModel model, int[] authors)
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
                // Salva a imagem
                string bookFile = "";
                var extension = Path.GetExtension(file.FileName);
                var name = Guid.NewGuid().ToString() + extension;
                bookFile = "/content/img/books/" + name;
                file.SaveAs(Path.Combine(Server.MapPath("~/content/img/books/"), name));

                // Recupera os autores
                var bookAuthors = _authorRepository.Get(authors);

                // Cria o livro
                var book = new Book(model.Title, model.ReleaseDate, model.ISBN, bookFile);

                // Adiciona os Autores
                book.ClearAuthors();
                foreach (Author author in bookAuthors)
                    book.AddAuthor(author);

                // Salva tudo
                _bookRepository.SaveOrUpdate(book);
                return RedirectToAction("Edit", new { id = book.Id });
            }
            catch (Exception ex)
            {
                ViewBag.Authors = _authorRepository.Get();
                ModelState.AddModelError("DefaultErrorMessage", "Falha ao salvar livro. <br />Detalhes do erro: " + ex.Message);
                return View(model);
            }
        }
        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            var book = _bookRepository.Get(id);
            var model = Mapper.Map<Book, EditorBookViewModel>(book);
            if (book == null)
                return HttpNotFound();

            ViewBag.Authors = _authorRepository.Get();
            ViewBag.SelectedAuthors = book.Authors;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditorBookViewModel model, int[] authors)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Authors = _authorRepository.Get();
                return View(model);
            }                

            if (Request.Files.Count == 0)
            {
                ViewBag.Authors = _authorRepository.Get();
                ModelState.AddModelError("DefaultErrorMessage", "Imagem inválida");
                return View(model);
            }

            var file = Request.Files[0];
            if (file == null || file.ContentLength <= 0)
            {
                ViewBag.Authors = _authorRepository.Get();
                ModelState.AddModelError("DefaultErrorMessage", "Imagem inválida");
                return View(model);
            }

            try
            {
                // Salva a imagem
                string bookFile = "";
                var extension = Path.GetExtension(file.FileName);
                var name = Guid.NewGuid().ToString() + extension;
                bookFile = "/content/img/books/" + name;
                file.SaveAs(Path.Combine(Server.MapPath("~/content/img/books/"), name));

                // Recupera o livro
                var book = _bookRepository.Get(model.Id);
                book.Title = model.Title;
                book.Image = bookFile;
                book.ISBN = model.ISBN;
                book.ReleaseDate = model.ReleaseDate;

                // Adiciona os Autores
                var bookAuthors = _authorRepository.Get(authors);
                book.ClearAuthors();
                foreach (Author author in bookAuthors)
                    book.AddAuthor(author);

                // Salva tudo
                _bookRepository.SaveOrUpdate(book);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Authors = _authorRepository.Get();
                ModelState.AddModelError("DefaultErrorMessage", "Falha ao salvar livro. <br />Detalhes do erro: " + ex.Message);
                return View(model);
            }
        }
        #endregion

        #region Delete
        public ActionResult Delete(int id)
        {
            var book = _bookRepository.Get(id);
            if (book == null)
                return HttpNotFound();

            return View(book);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                _bookRepository.Delete(id);
                return RedirectToAction("Index", "Book");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DefaultErrorMessage", "Falha ao excluir o livroo. <br />Detalhes do erro: " + ex.Message);
                return View(_bookRepository.Get(id));
            }
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            _bookRepository.Dispose();
        }
    }
}