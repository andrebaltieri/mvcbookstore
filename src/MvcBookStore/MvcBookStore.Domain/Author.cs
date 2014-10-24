using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace MvcBookStore.Domain
{
    public class Author
    {
        protected Author() { }

        public Author(string name, string bio)
        {
            Contract.Requires<Exception>(name.Length > 3, "O nome deve conter mais que 3 caracteres");
            Contract.Requires<Exception>(bio.Length > 3, "A biografia deve conter mais que 3 caracteres");

            this.Id = 0;
            this.Name = name;
            this.Bio = bio;
            this.Books = new List<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public void AddBook(Book book)
        {
            Contract.Requires<Exception>(book != null, "Livro inválido");
            Books.Add(book);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
