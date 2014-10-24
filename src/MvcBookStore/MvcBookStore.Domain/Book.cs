using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace MvcBookStore.Domain
{
    public class Book
    {
        protected Book() { }

        public Book(string title, string isbn, string image) : this(title, DateTime.Now, isbn, image) { }

        public Book(string title, DateTime releaseDate, string isbn, string image)
        {
            Contract.Requires<Exception>(title.Length > 3, "O título deve conter mais que 3 caracteres");
            Contract.Requires<Exception>(releaseDate != null, "A data de lançamento é obrigatória");
            Contract.Requires<Exception>(releaseDate.Date >= DateTime.Now.Date, "A data de lançamento deve ser no futuro");
            Contract.Requires<Exception>(isbn.Length > 10 && isbn.Length < 13, "O ISBN deve conter entre 10 e 13 caracteres");
            Contract.Requires<Exception>(!String.IsNullOrEmpty(image), "Imagem inválida");

            this.Id = 0;
            this.Title = title;
            this.ReleaseDate = releaseDate;
            this.ISBN = isbn;
            this.Image = image;
            this.Authors = new List<Author>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public int QuantitySaled { get; set; }
        public int QuantityOnHand { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public void AddAuthor(Author author)
        {
            Contract.Requires<Exception>(author != null, "Autor inválido");
            Authors.Add(author);
        }

        public void ClearAuthors()
        {
            Authors.Clear();
        }

        public void UpdateInventory(int quantity)
        {
            Contract.Requires<Exception>(quantity > 0, "Quantidade inválida");
            Contract.Requires<Exception>(quantity <= this.QuantityOnHand, "Produto sem estoque");

            this.QuantityOnHand -= quantity;
            this.QuantitySaled += quantity;
        }
    }
}
