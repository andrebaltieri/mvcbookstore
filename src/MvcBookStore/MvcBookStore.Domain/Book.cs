﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace MvcBookStore.Domain
{
    public class Book
    {
        private IList<Author> _authors;

        protected Book() { }

        public Book(string title, string isbn) : this(title, DateTime.Now, isbn) { }

        public Book(string title, DateTime releaseDate, string isbn)
        {
            Contract.Requires<Exception>(title.Length > 3, "O título deve conter mais que 3 caracteres");
            Contract.Requires<Exception>(releaseDate != null, "A data de lançamento é obrigatória");
            Contract.Requires<Exception>(releaseDate > DateTime.Now, "A data de lançamento deve ser no futuro");
            Contract.Requires<Exception>(isbn.Length > 10 && isbn.Length < 13, "O ISBN deve conter entre 10 e 13 caracteres");

            this.Id = 0;
            this.Title = title;
            this.ReleaseDate = releaseDate;
            this.ISBN = isbn;
            this._authors = new List<Author>();
        }

        public int Id { get; protected set; }
        public string Title { get; protected set; }
        public DateTime ReleaseDate { get; protected set; }
        public string ISBN { get; protected set; }
        public int QuantitySaled { get; set; }
        public int QuantityOnHand { get; set; }

        public IEnumerable<Author> Authors
        {
            get { return _authors; }
            protected set { _authors = new List<Author>(value); }
        }

        public void AddAuthor(Author author)
        {
            Contract.Requires<Exception>(author != null, "Autor inválido");
            _authors.Add(author);
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