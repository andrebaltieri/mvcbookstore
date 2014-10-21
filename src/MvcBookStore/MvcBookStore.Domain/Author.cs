using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace MvcBookStore.Domain
{
    public class Author
    {
         private IList<Book> _books;

        protected Author() { }

        public Author(string name, string bio)
        {
            Contract.Requires<Exception>(name.Length > 3, "O nome deve conter mais que 3 caracteres");
            Contract.Requires<Exception>(bio.Length > 3, "A biografia deve conter mais que 3 caracteres");

            this.Id = 0;
            this.Name = name;
            this.Bio = bio;
            this._books = new List<Book>();
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Bio { get; protected set; }

        public IEnumerable<Book> Books
        {
            get { return _books; }
            protected set { _books = new List<Book>(value); }
        }

        public void AddBook(Book book)
        {
            Contract.Requires<Exception>(book != null, "Livro inválido");
            _books.Add(book);
        }
    }
}
